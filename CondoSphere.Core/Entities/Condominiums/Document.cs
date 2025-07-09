using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Document : IEntity
    {
        /// <summary>
        /// The unique identifier for the document.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The foreign key to the condominium this document belongs to.
        /// </summary>
        public int CondominiumId { get; set; }

        /// <summary>
        /// The foreign key to the company that manages this condominium, for multi-tenancy.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The foreign key to the user who uploaded the document.
        /// </summary>
        public int UploadedByUserId { get; set; }

        /// <summary>
        /// The user-facing title of the document.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// A brief description of the document's content.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The original name of the file that was uploaded.
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// The path to the file in a physical location (e.g., on disk) or a full URL to its location in blob storage.
        /// </summary>
        public string FilePathOrUrl { get; set; } = string.Empty;

        /// <summary>
        /// The category of the document, used for filtering (e.g., "Minutes", "Regulation", "Budget").
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// The date and time the document was uploaded.
        /// </summary>
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;
    }
}
