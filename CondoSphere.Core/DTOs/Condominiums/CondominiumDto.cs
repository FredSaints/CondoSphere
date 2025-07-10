namespace CondoSphere.Core.DTOs.Condominiums
{
    /// <summary>
    /// Represents a condominium when being displayed to the user.
    /// </summary>
    public class CondominiumDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int CompanyId { get; set; }
    }
}
