using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Entidades.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Dominio.Servico
{
    public class InvestimentoServico: ServicoBase<Investimento>
    {
        public InvestimentoServico(DbFinancaContext oDbContexto): base(oDbContexto)
        {
        }
    }
}
