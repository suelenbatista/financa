using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Entidade.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Dominio.Servico
{
    public class PessoaServico : ServicoBase<Pessoa>
    {
        public PessoaServico(DbFinancaContext oDbContexto): base(oDbContexto)
        {
        }
    }
}
