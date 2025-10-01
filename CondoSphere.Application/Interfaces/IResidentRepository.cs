using CondoSphere.Core.Entities.Users; // ou onde estiver a tua entidade Resident/User

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// I Resident Repository.
    /// </summary>
    public interface IResidentRepository
    {
        Task<IReadOnlyList<Resident>> GetByCondominiumAsync(int condominiumId);
    }
}
