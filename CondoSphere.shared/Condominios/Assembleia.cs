using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.shared.Condominios
{
    public class Assembleia
    {
        public int IdAssembleia { get; set; }
        public DateTime Data { get; set; }
        public string Tema { get; set; }
        public string AtaURL { get; set; }
        public int IdCondominio { get; set; }
        public int IdEmpresa { get; set; }

    }
}
