using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Web.Models
{
    public class AssignResidentViewModel
    {
        [Required]
        public int UnitId { get; set; }
        [Required]
        public int CondominiumId { get; set; }

        [Required(ErrorMessage = "Please select a resident to assign.")]
        [Display(Name = "Select an Existing Resident")]
        public int SelectedResidentId { get; set; }

        public IEnumerable<SelectListItem> AvailableResidents { get; set; } = new List<SelectListItem>();
    }
}