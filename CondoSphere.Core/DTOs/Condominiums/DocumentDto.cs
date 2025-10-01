namespace CondoSphere.Core.DTOs.Condominiums
{
    /// <summary>
    /// Document DTO.
    /// </summary>
    public class DocumentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; }
        public string UploadedByUserName { get; set; } = string.Empty;
        public string CondominiumName { get; set; } = string.Empty;
    }
}