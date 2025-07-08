using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.shared.Condominios
{
    public class Intervencao
    {
        public int IdIntervencao { get; set; } 

        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public string Estado { get; set; }

        public int IdOcorrencia { get; set; } 

        public string TipoCobranca { get; set; } 

        public int? IdFracao { get; set; } 

        public int? IdCondominio { get; set; }

        public int IdEmpresa { get; set; }

    }
}
