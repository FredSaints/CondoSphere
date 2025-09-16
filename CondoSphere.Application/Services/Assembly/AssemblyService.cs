using System.Linq;
using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Assemblies;
using Microsoft.Extensions.Configuration;
using CoreAssembly = CondoSphere.Core.Entities.Assembly.Assembly;
using CondoSphere.Core.Entities.Assembly;
using CondoSphere.Core.Enums;

namespace CondoSphere.Application.Services.Assembly
{
    public class AssemblyService : IAssemblyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAssemblyRepository _assemblies;
        private readonly IAssemblyInviteRepository _invites;
        private readonly IAssemblyMessageRepository _messages;
        private readonly IAssemblyParticipantRepository _participants;
        private readonly ICurrentUserService _current;
        private readonly IMapper _mapper;
        private readonly IMailService _mail;
        private readonly ISmsService _sms;
        private readonly IPhoneNumberService _phone;
        private readonly IConfiguration _cfg;

        public AssemblyService(
            IUnitOfWork uow,
            IAssemblyRepository assemblies,
            IAssemblyInviteRepository invites,
            IAssemblyMessageRepository messages,
            IAssemblyParticipantRepository participants,
            ICurrentUserService current,
            IMapper mapper,
            IMailService mail,
            ISmsService sms,
            IPhoneNumberService phone,
            IConfiguration cfg)
        {
            _uow = uow;
            _assemblies = assemblies;
            _invites = invites;
            _messages = messages;
            _participants = participants;
            _current = current;
            _mapper = mapper;
            _mail = mail;
            _sms = sms;
            _phone = phone;
            _cfg = cfg;
        }

        public async Task<AssemblyDto?> CreateAsync(CreateAssemblyDto dto)
        {
            var userId = _current.UserId;
            var companyId = _current.CompanyId;
            if (userId == null || companyId == null) return null;

            var condo = await _uow.Condominiums.GetByIdAsync(dto.CondominiumId, companyId.Value);
            if (condo == null) return null;

            var isAdmin = _current.IsInRole(RoleConstants.CompanyAdmin);
            var isManager = _current.IsInRole(RoleConstants.CondoManager) && condo.ManagerId == userId.Value;
            if (!isAdmin && !isManager) return null;

            var entity = new CoreAssembly
            {
                CondominiumId = dto.CondominiumId,
                CompanyId = condo.CompanyId,
                Date = dto.ScheduledAt,
                Topic = dto.Title,
                MinutesUrl = null
            };

            await _assemblies.AddAsync(entity);
            await _uow.CompleteAsync();

            return _mapper.Map<AssemblyDto>(entity);
        }

        public async Task<IEnumerable<AssemblyDto>> GetForCondominiumAsync(int condominiumId)
        {
            var list = await _assemblies.GetByCondominiumAsync(condominiumId);
            return list.Select(_mapper.Map<AssemblyDto>);
        }

        public async Task<IEnumerable<AssemblyDto>> GetAllForCompanyAsync(int companyId)
        {
            var list = await _assemblies.GetAllForCompanyAsync(companyId);
            return list.Select(_mapper.Map<AssemblyDto>);
        }

        public async Task<int> SendInvitesAsync(int assemblyId, SendAssemblyInvitesDto dto)
        {
            var userId = _current.UserId;
            var companyId = _current.CompanyId;
            if (userId == null || companyId == null) return 0;

            var assembly = await _assemblies.GetByIdAsync(assemblyId);
            if (assembly == null || assembly.CompanyId != companyId.Value) return 0;

            var isAdmin = _current.IsInRole(RoleConstants.CompanyAdmin);

            var condo = await _uow.Condominiums.GetByIdAsync(assembly.CondominiumId, companyId.Value);
            var isManager = _current.IsInRole(RoleConstants.CondoManager) && condo?.ManagerId == userId.Value;

            if (!isAdmin && !isManager) return 0;

            // (UserId, Email, PhoneRaw)
            var recipients = new List<(int? UserId, string? Email, string? Phone)>();

            // 1) Todos os residentes do condomínio
            if (dto.InviteAllResidents)
            {
                var units = await _uow.Units.GetAllAsync(assembly.CondominiumId);
                var residentIds = units
                    .Where(u => u.ResidentId.HasValue)
                    .Select(u => u.ResidentId!.Value)
                    .Distinct()
                    .ToList();

                if (residentIds.Count > 0)
                {
                    var residents = await _uow.Users.GetUsersByIdsAsync(residentIds);
                    recipients.AddRange(residents.Select(r => ((int?)r.Id, r.Email, (string?)null)));
                }
            }

            // 2) Funcionários
            if (dto.IncludeEmployees)
            {
                var employees = await _uow.Users.GetUsersInRoleAsync(RoleConstants.Employee, companyId.Value);
                recipients.AddRange(employees.Select(e => ((int?)e.Id, e.Email, (string?)null)));
            }

            // 3) UserIds explícitos
            if (dto.UserIds != null && dto.UserIds.Any())
            {
                var users = await _uow.Users.GetUsersByIdsAsync(dto.UserIds);
                recipients.AddRange(users.Select(u => ((int?)u.Id, u.Email, (string?)null)));
            }

            // 4) Emails / Telefones diretos (filtrar vazios)
            var emails = (dto.Emails ?? Enumerable.Empty<string>())
                .Where(e => !string.IsNullOrWhiteSpace(e))
                .Select(e => e.Trim());

            var phones = (dto.PhoneNumbers ?? Enumerable.Empty<string>())
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Select(p => p.Trim());

            recipients.AddRange(emails.Select(e => ((int?)null, (string?)e, (string?)null)));
            recipients.AddRange(phones.Select(p => ((int?)null, (string?)null, (string?)p)));

            // 5) Deduplicar por UserId / email normalizado / telemóvel E.164
            //    - ignorar registos sem nenhum identificador
            recipients = recipients
                .Where(r => r.UserId.HasValue || !string.IsNullOrWhiteSpace(r.Email) || !string.IsNullOrWhiteSpace(r.Phone))
                .GroupBy(r =>
                {
                    if (r.UserId.HasValue) return $"U:{r.UserId.Value}";
                    if (!string.IsNullOrWhiteSpace(r.Email)) return $"E:{r.Email!.Trim().ToLowerInvariant()}";
                    var norm = string.IsNullOrWhiteSpace(r.Phone) ? null : _phone.Normalize(r.Phone);
                    return $"P:{norm}";
                })
                .Select(g => g.First())
                .ToList();

            var webBase = _cfg["ClientSettings:WebAppBaseUrl"]?.TrimEnd('/');
            var joinUrl = string.IsNullOrWhiteSpace(webBase)
                ? $"/assemblies/{assemblyId}"
                : $"{webBase}/assemblies/{assemblyId}";

            var invites = new List<AssemblyInvite>();
            int sent = 0;

            foreach (var r in recipients)
            {
                // Normalizar phone para E.164 (se existir)
                string? e164 = !string.IsNullOrWhiteSpace(r.Phone) ? _phone.Normalize(r.Phone) : null;
                string? email = string.IsNullOrWhiteSpace(r.Email) ? null : r.Email!.Trim();

                var channel =
                    (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(e164))
                        ? AssemblyInvitationChannel.Both
                        : (!string.IsNullOrWhiteSpace(email))
                            ? AssemblyInvitationChannel.Email
                            : AssemblyInvitationChannel.Sms;

                var invite = new AssemblyInvite
                {
                    AssemblyId = assemblyId,
                    InvitedUserId = r.UserId,
                    Email = email,
                    PhoneE164 = e164,
                    InvitedByUserId = userId.Value,
                    Channel = channel,
                    Status = AssemblyInviteStatus.Pending
                };

                invites.Add(invite);

                // Enviar email
                if (!string.IsNullOrWhiteSpace(email))
                {
                    var subject = dto.EmailSubject ?? "Convite para Assembleia do Condomínio";
                    var body = (dto.EmailBody ?? "Foi convidado para a assembleia.")
                             + $"<p>Data: {assembly.Date:dd/MM/yyyy HH:mm}</p>"
                             + $"<p>Título: {assembly.Topic}</p>"
                             + $"<p><a href=\"{joinUrl}\">Entrar na sala</a></p>";

                    await _mail.SendEmailAsync(email, subject, body);
                    sent++;
                }

                // Enviar SMS
                if (!string.IsNullOrWhiteSpace(e164))
                {
                    var sms = (dto.SmsBody ?? "Convite para assembleia.")
                            + $" {assembly.Topic} {assembly.Date:dd/MM HH:mm} {joinUrl}";

                    var res = await _sms.SendSmsAsync(e164, sms);
                    if (res.Success) sent++;
                }
            }

            if (invites.Count > 0)
                await _invites.AddRangeAsync(invites); // ✅ sem o erro de “..” e sem duplicar inserções

            await _uow.CompleteAsync();

            return sent; // ✅ devolve o total de mensagens enviadas
        }



        public async Task<IEnumerable<AssemblyMessageDto>> GetMessagesAsync(int assemblyId)
        {
            if (!await IsAuthorizedForAssemblyAsync(assemblyId, allowInvited: true))
                return Enumerable.Empty<AssemblyMessageDto>();

            var msgs = await _messages.GetByAssemblyAsync(assemblyId);
            return msgs.Select(m => new AssemblyMessageDto
            {
                Id = m.Id,
                AssemblyId = m.AssemblyId,
                SenderUserId = m.SenderUserId,
                SenderName = m.SenderName,
                Message = m.Message,
                CreatedAt = m.CreatedAt
            });
        }

        public async Task<AssemblyMessageDto?> PostMessageAsync(int assemblyId, PostAssemblyMessageDto dto)
        {
            var userId = _current.UserId;
            if (userId == null) return null;

            if (!await IsAuthorizedForAssemblyAsync(assemblyId, allowInvited: true))
                return null;

            var profile = await _uow.Users.GetUserByIdAsync(userId.Value);
            var name = (profile?.FirstName + " " + profile?.LastName)?.Trim() ?? "User";

            var msg = new AssemblyMessage
            {
                AssemblyId = assemblyId,
                SenderUserId = userId.Value,
                SenderName = name,
                Message = dto.Message
            };

            await _messages.AddAsync(msg);
            await _uow.CompleteAsync();

            return new AssemblyMessageDto
            {
                Id = msg.Id,
                AssemblyId = msg.AssemblyId,
                SenderUserId = msg.SenderUserId,
                SenderName = msg.SenderName,
                Message = msg.Message,
                CreatedAt = msg.CreatedAt
            };
        }

        private async Task<bool> IsAuthorizedForAssemblyAsync(int assemblyId, bool allowInvited)
        {
            var userId = _current.UserId;
            var companyId = _current.CompanyId;
            if (userId == null || companyId == null) return false;

            var assembly = await _assemblies.GetByIdAsync(assemblyId);
            if (assembly == null || assembly.CompanyId != companyId.Value) return false;

            if (_current.IsInRole(RoleConstants.CompanyAdmin)) return true;

            var condo = await _uow.Condominiums.GetByIdAsync(assembly.CondominiumId, companyId.Value);
            if (_current.IsInRole(RoleConstants.CondoManager) && condo?.ManagerId == userId.Value) return true;

            if (allowInvited)
            {
                var parts = await _participants.GetByAssemblyAsync(assemblyId);
                if (parts.Any(p => p.UserId == userId.Value)) return true;
            }

            return false;
        }
    }
}
