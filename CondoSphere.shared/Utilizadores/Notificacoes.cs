using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.shared.Utilizadores
{
    public class Notificacoes : IEntity
    {
        public int IdNotificacao { get; set; }

        public int IdUtilizador { get; set; }

        public int IdEmpresa { get; set; }

        public string Tipo { get; set; }

        public string Titulo { get; set; }

        public string Mensagem { get; set; }

        public DateTime DataEmissao { get; set; }
    }
}
