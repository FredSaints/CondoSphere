namespace CondoSphere.Web.Models
{
    public class ManageUnitAssignmentViewModel
    {
        public int UnitId { get; set; }
        public string UnitIdentifier { get; set; } = string.Empty;
        public int CondominiumId { get; set; }
        public AssignResidentViewModel AssignModel { get; set; } = new();
        public RegisterResidentViewModel RegisterModel { get; set; } = new();
    }
}