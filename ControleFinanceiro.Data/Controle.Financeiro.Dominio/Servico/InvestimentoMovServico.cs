using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Dominio.Servico
{
    public class InvestimentoMovServico: ServicoBase<InvestimentoMov>
    {
        public InvestimentoMovServico(DbFinancaContext oDbContext) : base(oDbContext)
        {
        }
    }
}
