using CondoSphere.Core.Entities.Users; // ou onde estiver a tua entidade Resident/User

namespace CondoSphere.Application.Interfaces
{
    public interface IResidentRepository
    {
        Task<IReadOnlyList<Resident>> GetByCondominiumAsync(int condominiumId);
    }
}
