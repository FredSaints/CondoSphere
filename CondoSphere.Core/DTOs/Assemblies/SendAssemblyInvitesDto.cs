namespace CondoSphere.Core.DTOs.Assemblies
{
    public class SendAssemblyInvitesDto
    {
        public bool InviteAllResidents { get; set; }
        public bool IncludeEmployees { get; set; }

        // usado pela UI da Web
        public List<int>? SelectedResidentIds { get; set; }

        // compat: ids vindos de outras UIs/APIs
        public IEnumerable<int>? UserIds { get; set; }

        public IEnumerable<string>? Emails { get; set; }
        public IEnumerable<string>? PhoneNumbers { get; set; }

        public string? EmailSubject { get; set; }
        public string? EmailBody { get; set; }
        public string? SmsBody { get; set; }


    }
}
