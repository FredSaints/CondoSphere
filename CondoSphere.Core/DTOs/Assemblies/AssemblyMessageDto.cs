using System;

namespace CondoSphere.Core.DTOs.Assemblies
{
    /// <summary>
    /// Assembly Message DTO.
    /// </summary>
    public class AssemblyMessageDto
    {
        public int Id { get; set; }
        public int AssemblyId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
    }
}
