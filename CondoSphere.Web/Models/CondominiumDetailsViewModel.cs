using CondoSphere.Core.DTOs.Condominiums;

namespace CondoSphere.Web.Models
{
    // A new class to hold combined Unit and Resident information for the view
    public class UnitDetailViewModel
    {
        public int Id { get; set; }
        public string Identifier { get; set; } = string.Empty;
        public int? ResidentId { get; set; }
        public string? ResidentName { get; set; }
    }

    public class CondominiumDetailsViewModel
    {
        public CondominiumDto Condominium { get; set; }
        // The list now uses our new, richer view model
        public IEnumerable<UnitDetailViewModel> Units { get; set; } = new List<UnitDetailViewModel>();
    }
}