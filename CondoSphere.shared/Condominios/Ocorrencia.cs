using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.shared.Condominios
{
    public class Ocorrencia
    {
        public int IdOcorrencia { get; set; }

        public string Descricao { get; set; }

        public DateTime DataRegisto { get; set; }

        public string Estado { get; set; }

        public int IdFracao { get; set; }

        public int IdEmpresa { get; set; }

        public int IdCondominio { get; set; } 

        public int IdUtilizador { get; set; }
    }
}
