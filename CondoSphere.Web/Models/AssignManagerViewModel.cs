using CondoSphere.Core.DTOs.Condominiums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Web.Models
{
    public class AssignManagerViewModel
    {
        [Required(ErrorMessage = "Please select a manager.")]
        [Display(Name = "Select Manager")]
        public int SelectedManagerId { get; set; }
    }
}