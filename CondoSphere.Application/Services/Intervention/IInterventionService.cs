using CondoSphere.Core;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.Enums;

namespace CondoSphere.Application.Services.Intervention
{
    public interface IInterventionService
    {
        Task<InterventionDto?> CreateInterventionAsync(CreateInterventionDto dto, int managerCompanyId);
        Task<IEnumerable<InterventionDto>> GetInterventionsForOccurrenceAsync(int occurrenceId);
        Task<IEnumerable<InterventionDto>> GetMyInterventionsAsync(int employeeId);
        Task<bool> UpdateInterventionStatusAsync(int interventionId, InterventionStatus newStatus);
    }
}