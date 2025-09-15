using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Messages;
using CondoSphere.Core.Entities.Messages;
using Microsoft.AspNetCore.Identity;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Messages
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<CoreUser> _userManager;

        public MessageService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<CoreUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<MessageDto> SendMessageAsync(SendMessageDto dto, int senderId, int companyId)
        {
            var sender = await _userManager.FindByIdAsync(senderId.ToString());
            var receiver = await _userManager.FindByIdAsync(dto.ReceiverId.ToString());

            if (sender == null) throw new ArgumentException("Invalid sender.");
            if (receiver == null) throw new ArgumentException("Invalid receiver.");

            if (sender.CompanyId != companyId || receiver.CompanyId != companyId)
                throw new ArgumentException("Users must belong to the same company.");

            var canSendMessage = await CanUsersCommunicate(sender, receiver.Id);
            if (!canSendMessage)
            {
                throw new System.Security.SecurityException("You do not have permission to send a message to this user.");
            }

            var message = new Message
            {
                SenderId = sender.Id,
                ReceiverId = receiver.Id,
                CompanyId = companyId,
                CondominiumId = dto.CondominiumId,
                Subject = dto.Subject,
                Content = dto.Content,
                SentDate = DateTime.UtcNow
            };

            await _unitOfWork.Messages.AddAsync(message);
            await _unitOfWork.CompleteAsync();

            var messageDto = _mapper.Map<MessageDto>(message);
            messageDto.SenderName = $"{sender.FirstName} {sender.LastName}".Trim();
            messageDto.ReceiverName = $"{receiver.FirstName} {receiver.LastName}".Trim();

            if (dto.CondominiumId.HasValue)
            {
                var condo = await _unitOfWork.Condominiums.GetByIdAsync(dto.CondominiumId.Value, companyId);
                messageDto.CondominiumName = condo?.Name;
            }

            return messageDto;
        }

        public async Task<IEnumerable<MessageListDto>> GetInboxAsync(int userId, int companyId, int pageNumber = 1, int pageSize = 20)
        {
            var messages = (await _unitOfWork.Messages.GetUserInboxAsync(userId, companyId, pageNumber, pageSize)).ToList();
            if (!messages.Any()) return Enumerable.Empty<MessageListDto>();

            var senderIds = messages.Select(m => m.SenderId).Distinct().ToList();
            var senders = (await _unitOfWork.Users.GetUsersByIdsAsync(senderIds)).ToDictionary(u => u.Id);

            var condoIds = messages.Where(m => m.CondominiumId.HasValue)
                                   .Select(m => m.CondominiumId!.Value)
                                   .Distinct()
                                   .ToList();

            var condoNames = new Dictionary<int, string>();
            foreach (var cid in condoIds)
            {
                var condo = await _unitOfWork.Condominiums.GetByIdAsync(cid, companyId);
                if (condo != null) condoNames[cid] = condo.Name;
            }

            var result = new List<MessageListDto>(messages.Count);
            foreach (var m in messages)
            {
                var dto = new MessageListDto
                {
                    Id = m.Id,
                    SenderName = senders.TryGetValue(m.SenderId, out var s) ? $"{s.FirstName} {s.LastName}" : "Unknown",
                    Subject = m.Subject,
                    SentDate = m.SentDate,
                    IsRead = m.IsRead
                };

                if (m.CondominiumId.HasValue && condoNames.TryGetValue(m.CondominiumId.Value, out var name))
                    dto.CondominiumName = name;

                result.Add(dto);
            }

            return result;
        }

        public async Task<IEnumerable<MessageListDto>> GetSentMessagesAsync(int userId, int companyId, int pageNumber = 1, int pageSize = 20)
        {
            var messages = (await _unitOfWork.Messages.GetUserSentMessagesAsync(userId, companyId, pageNumber, pageSize)).ToList();
            if (!messages.Any()) return Enumerable.Empty<MessageListDto>();

            var receiverIds = messages.Select(m => m.ReceiverId).Distinct().ToList();
            var receivers = (await _unitOfWork.Users.GetUsersByIdsAsync(receiverIds)).ToDictionary(u => u.Id);

            var condoIds = messages.Where(m => m.CondominiumId.HasValue)
                                   .Select(m => m.CondominiumId!.Value)
                                   .Distinct()
                                   .ToList();

            var condoNames = new Dictionary<int, string>();
            foreach (var cid in condoIds)
            {
                var condo = await _unitOfWork.Condominiums.GetByIdAsync(cid, companyId);
                if (condo != null) condoNames[cid] = condo.Name;
            }

            var result = new List<MessageListDto>(messages.Count);
            foreach (var m in messages)
            {
                var dto = new MessageListDto
                {
                    Id = m.Id,
                    ReceiverName = receivers.TryGetValue(m.ReceiverId, out var r) ? $"{r.FirstName} {r.LastName}" : "Unknown",
                    Subject = m.Subject,
                    SentDate = m.SentDate,
                    IsRead = m.IsRead
                };

                if (m.CondominiumId.HasValue && condoNames.TryGetValue(m.CondominiumId.Value, out var name))
                    dto.CondominiumName = name;

                result.Add(dto);
            }

            return result;
        }

        public async Task<MessageDto?> GetMessageByIdAsync(int messageId, int userId, int companyId)
        {
            var message = await _unitOfWork.Messages.GetByIdAsync(messageId);
            if (message == null || message.CompanyId != companyId ||
                (message.SenderId != userId && message.ReceiverId != userId))
            {
                return null;
            }

            var sender = await _userManager.FindByIdAsync(message.SenderId.ToString());
            var receiver = await _userManager.FindByIdAsync(message.ReceiverId.ToString());

            var dto = _mapper.Map<MessageDto>(message);
            dto.SenderName = $"{sender?.FirstName} {sender?.LastName}";
            dto.ReceiverName = $"{receiver?.FirstName} {receiver?.LastName}";

            if (message.CondominiumId.HasValue)
            {
                var condo = await _unitOfWork.Condominiums.GetByIdAsync(message.CondominiumId.Value, companyId);
                dto.CondominiumName = condo?.Name;
            }

            if (message.ReceiverId == userId && !message.IsRead)
            {
                await MarkAsReadAsync(messageId, userId, companyId);
            }

            return dto;
        }

        public async Task<int> GetUnreadCountAsync(int userId, int companyId)
        {
            return await _unitOfWork.Messages.GetUnreadCountAsync(userId, companyId);
        }

        public async Task<bool> MarkAsReadAsync(int messageId, int userId, int companyId)
        {
            var message = await _unitOfWork.Messages.GetByIdAsync(messageId);
            if (message == null || message.CompanyId != companyId || message.ReceiverId != userId)
            {
                return false;
            }

            await _unitOfWork.Messages.MarkAsReadAsync(messageId, userId);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<SimpleUserDto>> GetAvailableContactsAsync(int userId, int companyId)
        {
            var me = await _userManager.FindByIdAsync(userId.ToString());
            if (me == null) return Enumerable.Empty<SimpleUserDto>();

            var myRoles = await _userManager.GetRolesAsync(me);
            var allUsersInCompany = (await _unitOfWork.Users.GetCompanyUsersWithRolesAsync(companyId))
                                        .Where(u => u.Id != userId).ToList();

            var staffContacts = allUsersInCompany
                .Where(u => u.Role == RoleConstants.CompanyAdmin || u.Role == RoleConstants.CondoManager || u.Role == RoleConstants.Employee)
                .ToList();

            // Rule: All users can message staff.
            if (myRoles.Contains(RoleConstants.CondoResident))
            {
                return staffContacts.Select(u => _mapper.Map<SimpleUserDto>(u)).OrderBy(c => c.FullName);
            }

            // At this point, we know the user is a staff member. They can always contact other staff.
            var residentContacts = new List<UserListDto>();

            if (myRoles.Contains(RoleConstants.CompanyAdmin))
            {
                // Admins can contact all residents.
                residentContacts = allUsersInCompany.Where(u => u.Role == RoleConstants.CondoResident).ToList();
            }
            else if (myRoles.Contains(RoleConstants.CondoManager))
            {
                // Managers can contact residents of their assigned condos.
                var managedCondos = await _unitOfWork.Condominiums.GetByManagerIdAsync(userId);
                var managedCondoIds = managedCondos.Select(c => c.Id).ToList();

                var allUnits = new List<CondoSphere.Core.Entities.Condominiums.Unit>();
                foreach (var condoId in managedCondoIds)
                {
                    allUnits.AddRange(await _unitOfWork.Units.GetAllAsync(condoId));
                }

                var residentIds = allUnits.Where(u => u.ResidentId.HasValue).Select(u => u.ResidentId.Value).ToHashSet();
                residentContacts = allUsersInCompany.Where(u => u.Role == RoleConstants.CondoResident && residentIds.Contains(u.Id)).ToList();
            }
            else if (myRoles.Contains(RoleConstants.Employee))
            {
                // Employees can contact residents for whom they have an open task.
                var openInterventions = await _unitOfWork.Interventions.GetByAssignedUserIdAsync(userId);
                var openOccurrenceIds = openInterventions.Select(i => i.OccurrenceId).ToHashSet();

                var openOccurrences = new List<CondoSphere.Core.Entities.Condominiums.Occurrence>();
                foreach (var occId in openOccurrenceIds)
                {
                    var occ = await _unitOfWork.Occurrences.GetByIdAsync(occId);
                    if (occ != null) openOccurrences.Add(occ);
                }

                var residentIds = openOccurrences.Select(o => o.ReportedByUserId).ToHashSet();
                residentContacts = allUsersInCompany.Where(u => u.Role == RoleConstants.CondoResident && residentIds.Contains(u.Id)).ToList();
            }

            return staffContacts.Concat(residentContacts)
                                .GroupBy(u => u.Id).Select(g => g.First()) // Ensure uniqueness
                                .Select(u => _mapper.Map<SimpleUserDto>(u))
                                .OrderBy(c => c.FullName);
        }


        private bool IsStaffMember(IList<string> roles)
        {
            return roles.Contains(RoleConstants.CompanyAdmin) ||
                   roles.Contains(RoleConstants.CondoManager) ||
                   roles.Contains(RoleConstants.Employee);
        }

        private async Task<bool> CanUsersCommunicate(CoreUser sender, int receiverId)
        {
            var contacts = await GetAvailableContactsAsync(sender.Id, sender.CompanyId.Value);
            return contacts.Any(c => c.Id == receiverId);
        }
    }
}