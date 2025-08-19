namespace CondoSphere.Core.DTOs.Account
{
    /// <summary>
    /// A simplified user DTO for nesting inside other DTOs to prevent circular references.
    /// </summary>
    public class SimpleUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}