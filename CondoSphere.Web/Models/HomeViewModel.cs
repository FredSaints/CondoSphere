using CondoSphere.Web.Models.Home;

namespace CondoSphere.Web.Models
{
    public class HomeViewModel
    {
        public List<FeatureViewModel> Features { get; set; } = new();
        public List<PersonaViewModel> Personas { get; set; } = new();
        public List<TestimonialViewModel> Testimonials { get; set; } = new();
    }
}
