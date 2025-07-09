using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Users
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? VatNumber { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
