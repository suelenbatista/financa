using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Model
{
    public class MovimentoRateio
    {
        public int IdMovRateio { get; set; }
        public int IdMov { get; set; }
        public int IdContaContabil { get; set; }
        public int IdCentro { get; set; }
        public decimal PercRateio { get; set; }
        public decimal ValorRateio { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string Obs { get; set; }

        public virtual Movimento Movimento { get; set; }
        public virtual ContaContabil ContaContabil { get; set; }
        public virtual CentroContabil CentroContabil { get; set; }
    }
}
