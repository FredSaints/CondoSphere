using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.DTOs.Assemblies
{
    public class SendAssemblyInvitesDto
    {
        public bool InviteAllResidents { get; set; }
        public bool IncludeEmployees { get; set; } // empregados da empresa do condomínio

        // convidados explícitos
        public List<int> UserIds { get; set; } = new();
        public List<string> Emails { get; set; } = new();
        public List<string> PhoneNumbers { get; set; } = new();

        // conteúdos das notificações
        [StringLength(200)]
        public string? EmailSubject { get; set; } = "Convite para Assembleia do Condomínio";
        public string? EmailBody { get; set; }
        public string? SmsBody { get; set; }
    }
}
