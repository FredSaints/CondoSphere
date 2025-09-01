namespace CondoSphere.Web.Models.Home
{
    public class PersonaViewModel
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string RoleTitle { get; set; } = string.Empty;
        public List<string> Benefits { get; set; } = new();
    }
}
