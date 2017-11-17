using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Dominio.Servico;
using ControleFinanceiro.Entidade.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFinanceiro.ServicosRest.Models
{
    public class InvestimentoModel : IDisposable
    {
        DbFinancaContext oDbFinancaContext;
        InvestimentoServico oServico;

        public InvestimentoModel()
        {
            oDbFinancaContext = new DbFinancaContext();
            oServico = new InvestimentoServico(oDbFinancaContext);
        }

        public List<Investimento> ObterInvestimento()
        {
            List<Investimento> oListaInvestimento = oServico.Listar();
            return oListaInvestimento;
        }

        public Investimento ObterInvestimentoPorId(int id)
        {
            return oServico.ObterPorId(id);
        }

        public bool CadastrarInvestimento(Investimento Investimento)
        {
            try
            {
                oServico.Adicionar(Investimento);
                oServico.SalvarContexto();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool DeletarInvestimento(int id)
        {
            bool isDeleted = false;

            try
            {
                Investimento Investimento = ObterInvestimentoPorId(id);
                if (Investimento != null)
                {
                    oServico.Remover(Investimento);
                    oServico.SalvarContexto();
                    isDeleted = true;
                }

                return isDeleted;
            }
            catch (Exception)
            {
                return isDeleted;
            }
        }

        public bool AtualizarInvestimento(int id, Investimento InvestimentoUpdate)
        {
            bool isUpdate = false;

            try
            {
                Investimento Investimento = ObterInvestimentoPorId(id);

                if (Investimento != null)
                {
                    oServico.Alterar(InvestimentoUpdate, id);
                    oServico.SalvarContexto();
                    isUpdate = true;
                }

                return isUpdate;
            }
            catch (Exception)
            {
                return isUpdate;
            }
        }

        public void Dispose()
        {
            oServico.Dispose();
            oDbFinancaContext.Dispose();
        }
    }
}