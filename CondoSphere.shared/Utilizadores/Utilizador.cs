using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.shared.Utilizadores
{
    public class Utilizador: IdentityUser
    {
        public int IdUtilizador { get; set; }

        public int IdEmpresa { get; set; }

        public int IdCondominio { get; set; }

        public int IdFracao { get; set; }

        public string NomeUtilizador { get; set; }

        public string EmailUtilizador { get; set; }

        public string PasswordUtilizador { get; set; }
    
    }
}
