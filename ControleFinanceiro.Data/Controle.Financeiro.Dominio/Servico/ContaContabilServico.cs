using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Entidade.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Dominio.Servico
{
    public class ContaContabilServico: ServicoBase<ContaContabil>
    {
        private DbFinancaContext _DbContexto;

        public ContaContabilServico(DbFinancaContext oDbContexto): base(oDbContexto)
        {
            _DbContexto = oDbContexto;
        }

        public List<ContaContabil> ObterPorDescricao(string descricao)
        {
            List<ContaContabil> oListaContaContabil = _DbContexto.ContaContabil.Where(o => o.Descricao.Contains(descricao)).ToList();
            return oListaContaContabil;
        }

        public ContaContabil ObterPorCodigo(string codigo)
        {
            ContaContabil oContaContabil = _DbContexto.ContaContabil.Where(o => o.Codigo.Equals(codigo)).First();
            return oContaContabil;
        }

    }

}
