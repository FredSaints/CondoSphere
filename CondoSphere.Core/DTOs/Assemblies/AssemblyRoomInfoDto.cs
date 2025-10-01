namespace CondoSphere.Core.DTOs.Assemblies
{
    /// <summary>
    /// Assembly Room Info DTO.
    /// </summary>
    public class AssemblyRoomInfoDto
    {
        public int AssemblyId { get; set; }
        public string RoomName { get; set; } = string.Empty;   // ex.: Jitsi room
        public string JoinUrl { get; set; } = string.Empty;    // link completo para entrar
        public string? Password { get; set; }                   // se aplicável
        public bool CanPostMessages { get; set; }               // permissão p/ chat
    }
}
