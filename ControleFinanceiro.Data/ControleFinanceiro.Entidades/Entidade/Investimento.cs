using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Entidades.Entidade
{
    public class Investimento
    {
        public int IdInvest { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<InvestimentoMov> InvestimentoMov { get; set; }
    }
}
