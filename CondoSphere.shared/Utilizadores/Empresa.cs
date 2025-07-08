using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.shared.Utilizadores
{
    public class Empresa: IEntity
    {
        public int IdEmpresa { get; set; }

        public string NomeEmpresa { get; set; }

        public string EmailEmpresa { get; set; }

        public string TelefoneEmpresa { get; set; }

    }
}
