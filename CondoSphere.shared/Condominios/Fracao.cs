using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.shared.Condominios
{
    public class Fracao
    {
        public int IdFracao { get; set; } 

        public string Identificador { get; set; }

        public int IdCondominio { get; set; }

        public int IdProprietario { get; set; }

        public int IdEmpresa { get; set; }
    }
}
