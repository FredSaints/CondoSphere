namespace CondoSphere.Core.DTOs.Assemblies
{
    public class AssemblyRoomInfoDto
    {
        public int AssemblyId { get; set; }
        public string RoomName { get; set; } = string.Empty;   // ex.: Jitsi room
        public string JoinUrl { get; set; } = string.Empty;    // link completo para entrar
        public string? Password { get; set; }                   // se aplicável
        public bool CanPostMessages { get; set; }               // permissão p/ chat
    }
}
