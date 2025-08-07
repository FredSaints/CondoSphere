namespace CondoSphere.Core.DTOs.Account
{
    // This DTO represents the full profile data we need on the frontend.
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ProfilePictureUrl { get; set; }
        public int? CompanyId { get; set; }
        public IEnumerable<string> Roles { get; set; } = new List<string>();
    }
}