using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Entidade.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Dominio.Servico
{
    public class CentroContabilServico : ServicoBase<CentroContabil>
    {
        private DbFinancaContext _DbContexto;

        public CentroContabilServico(DbFinancaContext oDbContexto) : base(oDbContexto)
        {
            _DbContexto = oDbContexto;
        }

        public List<CentroContabil> ObterPorDescricao (string descricao)
        {
            List<CentroContabil> oListaCentro = _DbContexto.CentroContabil.Where(o => o.Descricao.Contains(descricao)).ToList();
            return oListaCentro;
        }

        public CentroContabil ObterPorCodigo(string codigo)
        {
            CentroContabil oCentroCusto = _DbContexto.CentroContabil.Where(o => o.Codigo.Equals(codigo)).First();
            return oCentroCusto;
        }
    }
}
