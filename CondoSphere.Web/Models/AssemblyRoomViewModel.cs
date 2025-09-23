using CondoSphere.Core.DTOs.Assemblies;
public class AssemblyRoomViewModel
{
    public int AssemblyId { get; set; }
    public AssemblyRoomInfoDto Room { get; set; } = default!;
    public List<AssemblyMessageDto> Messages { get; set; } = new();
}
