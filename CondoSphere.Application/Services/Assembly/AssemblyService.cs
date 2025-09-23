using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Messages;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Assemblies;
using CondoSphere.Core.DTOs.Messages;
using CondoSphere.Core.Entities.Assembly;
using CondoSphere.Core.Enums;
using Microsoft.Extensions.Configuration;
using AssemblyEntity = CondoSphere.Core.Entities.Assembly.Assembly;

namespace CondoSphere.Application.Services.Assembly
{
    public class AssemblyService : IAssemblyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAssemblyRepository _assemblies;
        private readonly IAssemblyInviteRepository _invites;
        private readonly IAssemblyParticipantRepository _participants;
        private readonly ICurrentUserService _current;
        private readonly IMailService _mail;
        private readonly ISmsService _sms;
        private readonly IPhoneNumberService _phone;
        private readonly IInAppNotificationService _inAppNotify;
        private readonly IConfiguration _cfg;
        private readonly IResidentRepository _residents;
        private readonly IMessageService _messages;                


        public AssemblyService(
              IUnitOfWork uow,
              IAssemblyRepository assemblies,
              IAssemblyInviteRepository invites,
              IAssemblyParticipantRepository participants,
              ICurrentUserService current,
              IMailService mail,
              ISmsService sms,
              IMessageService messages,
              IPhoneNumberService phone,
              IInAppNotificationService inAppNotify,
              IConfiguration cfg,
              IResidentRepository residents)              
        {
            _uow = uow;
            _assemblies = assemblies;
            _invites = invites;
            _participants = participants;
            _current = current;
            _mail = mail;
            _sms = sms;
            _messages = messages;
            _phone = phone;
            _inAppNotify = inAppNotify;
            _cfg = cfg;
            _residents = residents;                     
        }

        // ========= CREATE =========
        public async Task<AssemblyDto?> CreateAsync(CreateAssemblyDto dto)
        {
            var userCompany = _current.CompanyId;
            if (userCompany == null) return null;

            var entity = new AssemblyEntity
            {
                CompanyId = userCompany.Value,
                CondominiumId = dto.CondominiumId,
                Date = dto.Date,
                Topic = dto.Topic
            };

            entity.JitsiRoomName = $"condosphere-c{entity.CompanyId}-cd{entity.CondominiumId}-a{Guid.NewGuid():N}";
            entity.JitsiRoomPassword = null;

            await _assemblies.AddAsync(entity);
            await _uow.CompleteAsync();

            var dtoOut = Map(entity);

            // preencher nome do condomínio (Opção B) — precisa do companyId
            var condo = await _uow.Condominiums.GetByIdAsync(entity.CondominiumId, entity.CompanyId);
            dtoOut.CondominiumName = condo?.Name;

            return dtoOut;
        }

        public Task<IEnumerable<AssemblyDto>> GetByCondominiumAsync(int condominiumId)
            => GetForCondominiumAsync(condominiumId);

        // ========= LISTS =========
        public async Task<IEnumerable<AssemblyDto>> GetForCondominiumAsync(int condominiumId)
        {
            var list = await _assemblies.GetByCondominiumAsync(condominiumId);

            // buscar nome do condomínio uma única vez (scoped à empresa atual)
            var companyId = _current.CompanyId ?? 0;
            string? condoName = null;
            if (companyId > 0)
            {
                var condo = await _uow.Condominiums.GetByIdAsync(condominiumId, companyId);
                condoName = condo?.Name;
            }

            return list.Select(a => new AssemblyDto
            {
                Id = a.Id,
                CompanyId = a.CompanyId,
                CondominiumId = a.CondominiumId,
                CondominiumName = condoName,
                Date = a.Date,
                Topic = a.Topic ?? string.Empty,
                JitsiRoomName = a.JitsiRoomName,
                JitsiRoomPassword = a.JitsiRoomPassword,
            });
        }

        public async Task<IEnumerable<AssemblyDto>> GetAllForCompanyAsync(int companyId)
        {
            var list = await _assemblies.GetAllForCompanyAsync(companyId);

            // lookup de nomes de condomínios (evita N+1)
            var condoIds = list.Select(a => a.CondominiumId).Distinct().ToList();
            var condos = await _uow.Condominiums.GetByIdsAsync(condoIds);
            var condoNameById = condos.ToDictionary(c => c.Id, c => c.Name);

            return list.Select(a => new AssemblyDto
            {
                Id = a.Id,
                CompanyId = a.CompanyId,
                CondominiumId = a.CondominiumId,
                CondominiumName = condoNameById.TryGetValue(a.CondominiumId, out var n) ? n : null,
                Date = a.Date,
                Topic = a.Topic ?? string.Empty,
                JitsiRoomName = a.JitsiRoomName,
                JitsiRoomPassword = a.JitsiRoomPassword,
            });
        }

        // ========= READ =========
        public async Task<AssemblyDto?> GetByIdAsync(int id)
        {
            var a = await _assemblies.GetByIdAsync(id);
            if (a == null) return null;

            var dto = Map(a);

            // trazer o nome do condomínio (precisa de companyId da própria entidade)
            var condo = await _uow.Condominiums.GetByIdAsync(a.CondominiumId, a.CompanyId);
            dto.CondominiumName = condo?.Name;

            return dto;
        }

        // ========= UPDATE =========
        public async Task<AssemblyDto?> UpdateAsync(int id, AssemblyDto dto)
        {
            var existing = await _assemblies.GetByIdAsync(id);
            if (existing == null) return null;

            if (_current.CompanyId.HasValue && existing.CompanyId != _current.CompanyId.Value)
                return null;

            existing.Topic = dto.Topic;
            existing.Date = dto.Date;

            if (dto.CondominiumId > 0 && dto.CondominiumId != existing.CondominiumId)
            {
                existing.CondominiumId = dto.CondominiumId;
                // (opcional) regenerar JitsiRoomName se quiseres atar ao condomínio
                // existing.JitsiRoomName = $"condosphere-c{existing.CompanyId}-cd{existing.CondominiumId}-a{existing.Id}";
            }

            _assemblies.Update(existing);
            await _uow.CompleteAsync();

            var outDto = Map(existing);
            var condo = await _uow.Condominiums.GetByIdAsync(existing.CondominiumId, existing.CompanyId);
            outDto.CondominiumName = condo?.Name;
            return outDto;
        }

        public async Task<int> SendInvitesAsync(int assemblyId, SendAssemblyInvitesDto dto)
        {
            var asm = await _assemblies.GetByIdAsync(assemblyId);
            if (asm == null) return 0;

            var recipients = new List<(string? Email, string? PhoneE164, int? UserId)>();

            // a) Residentes
            var condoResidents = await _residents.GetByCondominiumAsync(asm.CondominiumId);
            if (dto.InviteAllResidents)
            {
                recipients.AddRange(condoResidents.Select(r => (r.Email, _phone.Normalize(r.PhoneNumber), (int?)r.Id)));
            }
            else
            {
                var selectedIds = (dto.SelectedResidentIds ?? dto.UserIds?.ToList() ?? new List<int>())
                    .Distinct().ToHashSet();
                if (selectedIds.Count > 0)
                {
                    recipients.AddRange(
                        condoResidents.Where(r => selectedIds.Contains(r.Id))
                                      .Select(r => (r.Email, _phone.Normalize(r.PhoneNumber), (int?)r.Id)));
                }
            }

            // b) Funcionários (role Employee)
            if (dto.IncludeEmployees)
            {
                var emps = await _uow.Users.GetUsersInRoleAsync(RoleConstants.Employee, asm.CompanyId);
                recipients.AddRange(emps.Select(e => (e.Email, (string?)null, (int?)e.Id)));
            }

            // c) Ad-hoc
            if (dto.Emails != null)
                recipients.AddRange(dto.Emails.Where(e => !string.IsNullOrWhiteSpace(e))
                    .Select(e => (e.Trim(), (string?)null, (int?)null)));

            if (dto.PhoneNumbers != null)
                recipients.AddRange(dto.PhoneNumbers.Where(p => !string.IsNullOrWhiteSpace(p))
                    .Select(p => ((string?)null, _phone.Normalize(p), (int?)null)));

            // Distintos/válidos
            var emails = recipients.Select(x => x.Email).Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct(StringComparer.OrdinalIgnoreCase).ToList();
            var phones = recipients.Select(x => x.PhoneE164).Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct().ToList();
            var userIds = recipients.Select(x => x.UserId).Where(id => id.HasValue)
                .Select(id => id!.Value).Distinct().ToList();

            if (emails.Count == 0 && phones.Count == 0 && userIds.Count == 0) return 0;

            // Conteúdo com link direto Jitsi
            var room = string.IsNullOrWhiteSpace(asm.JitsiRoomName)
                ? $"condosphere-c{asm.CompanyId}-cd{asm.CondominiumId}-a{asm.Id}"
                : asm.JitsiRoomName!;
            var jitsiBase = _cfg["Jitsi:PublicBaseUrl"]?.TrimEnd('/') ?? "https://meet.jit.si";
            var joinUrl = $"{jitsiBase}/{room}";

            var subject = string.IsNullOrWhiteSpace(dto.EmailSubject)
                ? $"Convocatória: {asm.Topic} – {asm.Date:dd/MM/yyyy HH:mm}"
                : dto.EmailSubject!;
            var emailBody = string.IsNullOrWhiteSpace(dto.EmailBody)
                ? $"<p>Olá,</p><p>Está convocado(a) para a assembleia <strong>\"{asm.Topic}\"</strong> em {asm.Date:dd/MM/yyyy HH:mm}.</p><p>Entrar: <a href=\"{joinUrl}\">{joinUrl}</a></p>"
                : dto.EmailBody!;
            var smsBody = string.IsNullOrWhiteSpace(dto.SmsBody)
                ? $"Assembleia \"{asm.Topic}\" {asm.Date:dd/MM HH:mm}. Entrar: {joinUrl}"
                : dto.SmsBody!;

            // versão plaintext para Mensagens internas
            var messageContent =
                $"Está convocado(a) para a assembleia \"{asm.Topic}\" em {asm.Date:dd/MM/yyyy HH:mm}." +
                $"\nEntrar: {joinUrl}";

            // Envio: Email
            var sent = 0;
            foreach (var e in emails)
            {
                await _mail.SendEmailAsync(e!, subject, emailBody);
                sent++;
            }

            // Envio: SMS
            foreach (var p in phones)
            {
                var res = await _sms.SendSmsAsync(p!, smsBody);
                if (res.Success) sent++;
            }

            // Envio: Mensagens internas + Notificação in-app (apenas para destinatários com UserId)
            if (_current.UserId != null)
            {
                foreach (var uid in userIds)
                {
                    // Inbox (Messages)
                    await _messages.SendMessageAsync(
                        new SendMessageDto
                        {
                            ReceiverId = uid,
                            CondominiumId = asm.CondominiumId,
                            Subject = subject,
                            Content = messageContent
                        },
                        _current.UserId.Value,
                        asm.CompanyId
                    );

                    // Sino/Push (NotificationHub)
                    await _inAppNotify.NotifyAsync(
                        uid,
                        subject,
                        $"Clique para entrar na reunião: {asm.Topic}",
                        joinUrl
                    );
                }
            }

            // Audit trail (AssemblyInvites)
            var inviteRows = new List<AssemblyInvite>();
            inviteRows.AddRange(emails.Select(e => new AssemblyInvite
            {
                AssemblyId = asm.Id,
                CompanyId = asm.CompanyId,
                CondominiumId = asm.CondominiumId,
                Email = e,
                InvitedByUserId = _current.UserId ?? 0,
                Channel = AssemblyInvitationChannel.Email,
                SentAt = DateTime.UtcNow
            }));
            inviteRows.AddRange(phones.Select(p => new AssemblyInvite
            {
                AssemblyId = asm.Id,
                CompanyId = asm.CompanyId,
                CondominiumId = asm.CondominiumId,
                PhoneE164 = p,
                InvitedByUserId = _current.UserId ?? 0,
                Channel = AssemblyInvitationChannel.Sms,
                SentAt = DateTime.UtcNow
            }));
            if (inviteRows.Count > 0)
            {
                await _invites.AddRangeAsync(inviteRows);
                await _uow.CompleteAsync();
            }

            return sent;
        }





        // ========= CHAT (placeholders) =========
        public Task<IEnumerable<AssemblyMessageDto>> GetMessagesAsync(int assemblyId)
        {
            IEnumerable<AssemblyMessageDto> empty = new List<AssemblyMessageDto>();
            return Task.FromResult(empty);
        }

        public Task<AssemblyMessageDto?> PostMessageAsync(int assemblyId, PostAssemblyMessageDto dto)
        {
            if (_current.UserId is null) return Task.FromResult<AssemblyMessageDto?>(null);

            var msg = new AssemblyMessageDto
            {
                Id = 0,
                AssemblyId = assemblyId,
                UserId = _current.UserId.Value,
                UserName = _current.UserEmail ?? "user",
                Message = dto.Message ?? string.Empty,
                SentAt = DateTime.UtcNow
            };
            return Task.FromResult<AssemblyMessageDto?>(msg);
        }

        // ========= ROOM INFO =========
        public async Task<AssemblyRoomInfoDto?> GetRoomInfoAsync(int assemblyId)
        {
            var asm = await _assemblies.GetByIdAsync(assemblyId);
            if (asm == null || asm.CompanyId != _current.CompanyId) return null;

            var room = string.IsNullOrWhiteSpace(asm.JitsiRoomName)
                ? $"condosphere-c{asm.CompanyId}-cd{asm.CondominiumId}-a{asm.Id}"
                : asm.JitsiRoomName!;

            var joinUrl = $"https://meet.jit.si/{room}";
            return new AssemblyRoomInfoDto
            {
                AssemblyId = asm.Id,
                RoomName = room,
                JoinUrl = joinUrl,
                Password = asm.JitsiRoomPassword,
                CanPostMessages = true
            };
        }

        // ========= MAP =========
        private static AssemblyDto Map(AssemblyEntity a) => new()
        {
            Id = a.Id,
            CompanyId = a.CompanyId,
            CondominiumId = a.CondominiumId,
            Date = a.Date,
            Topic = a.Topic ?? string.Empty,
            JitsiRoomName = a.JitsiRoomName,
            JitsiRoomPassword = a.JitsiRoomPassword
        };
    }
}
