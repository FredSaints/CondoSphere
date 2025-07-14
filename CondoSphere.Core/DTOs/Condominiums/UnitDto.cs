namespace CondoSphere.Core.DTOs.Condominiums
{
    /// <summary>
    /// Represents a Unit when being displayed to the user.
    /// </summary>
    public class UnitDto
    {
        public int Id { get; set; }
        public string Identifier { get; set; } = string.Empty;
        public int CondominiumId { get; set; }
    }
}
