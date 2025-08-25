using System.ComponentModel.DataAnnotations;
namespace CondoSphere.Web.Models
{
    public class TwoFactorVerifyViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string SelectedMethod { get; set; } = "Email";
        public string Code { get; set; } = string.Empty;
    }
}
