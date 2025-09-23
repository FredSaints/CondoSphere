using Microsoft.AspNetCore.SignalR;

namespace CondoSphere.Shared.Hubs
{
    public class AssemblyChatHub : Hub
    {
        public static string Group(int assemblyId) => $"asm-{assemblyId}";
    }
}
