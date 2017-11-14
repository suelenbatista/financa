using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Entidades.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Dominio.Servico
{
    public class MovimentoServico: ServicoBase<Movimento>
    {
        public MovimentoServico(DbFinancaContext oDbContext) :base (oDbContext)
        {
        }
    }
}
