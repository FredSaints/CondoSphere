namespace CondoSphere.Core.DTOs.Reports
{
    /// <summary>
    /// Status Summary DTO.
    /// </summary>
    public class StatusSummaryDto
    {
        public string StatusName { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}