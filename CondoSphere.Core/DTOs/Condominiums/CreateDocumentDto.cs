using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Condominiums
{
    /// <summary>
    /// Create Document DTO.
    /// </summary>
    public class CreateDocumentDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;
    }
}