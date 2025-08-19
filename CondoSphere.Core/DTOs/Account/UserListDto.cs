using CondoSphere.Core.DTOs.Condominiums;

namespace CondoSphere.Core.DTOs.Account
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<int> AssignedUnitIds { get; set; } = new List<int>();
        public string FullName => $"{FirstName} {LastName}";
    }
}