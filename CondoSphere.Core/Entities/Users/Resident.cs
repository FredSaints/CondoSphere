namespace CondoSphere.Core.Entities.Users
{
    public class Resident
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string Name => $"{FirstName} {LastName}";
    }
}
