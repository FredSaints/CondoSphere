using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.shared.Financeira
{
    public class Recibos
    {
        public int IdRecibo { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataEmissao { get; set; }

        public int IdPagamento { get; set; }

        public string Detalhes { get; set; }
    }
}
