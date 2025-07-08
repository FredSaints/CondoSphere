using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.shared.Financeira
{
    public class PagamentosQuota
    {
        public int IdPagamento { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataPagamento { get; set; }

        public DateTime? DataFim { get; set; }

        public string Metodo { get; set; }

        public string TipoOrigem { get; set; }

        public int? IdQuota { get; set; }

        public int? IdOrigem { get; set; }

        public int IdFracao { get; set; }

        public int IdEmpresa { get; set; }
    }
}
