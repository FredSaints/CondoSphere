namespace CondoSphere.Mobile.Services
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
    }

    public class CreateOccurrenceRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UnitId { get; set; }
        public FileResult? ImageFile { get; set; }
    }

    public class InterventionDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string Status { get; set; }
        public string AssignedToUserName { get; set; }
    }
}