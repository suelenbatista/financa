using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Entidade.Entidade
{
    public class InvestimentoMov
    {
        public int IdInvestMov { get; set; }
        public int IdInvest { get; set; }
        public int IdConta { get; set; }

        public string Envolvido { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal Rentabilidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataCompra { get; set; }
        public DateTime DataVencimento { get; set; }

        public virtual Investimento Investimento { get; set; }
        public virtual ContaBancaria ContaBancaria { get; set; }
    }
}
