using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Dominio.Servico;
using ControleFinanceiro.Entidade.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFinanceiro.ServicosRest.Models
{
    public class InvestimentoMovModel :IDisposable
    {
        DbFinancaContext oDbFinancaContext;
        InvestimentoMovServico oServico;

        public InvestimentoMovModel()
        {
            oDbFinancaContext = new DbFinancaContext();
            oServico = new InvestimentoMovServico(oDbFinancaContext);
        }

        public List<InvestimentoMov> ObterInvestimentoMov()
        {
            List<InvestimentoMov> oListaInvestimentoMov = oServico.Listar();
            return oListaInvestimentoMov;
        }

        public InvestimentoMov ObterInvestimentoMovPorId(int id)
        {
            return oServico.ObterPorId(id);
        }

        public bool CadastrarInvestimentoMov(InvestimentoMov investimentoMov)
        {
            try
            {
                oServico.Adicionar(investimentoMov);
                oServico.SalvarContexto();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool DeletarInvestimentoMov(int id)
        {
            bool isDeleted = false;

            try
            {
                InvestimentoMov investimentoMov = ObterInvestimentoMovPorId(id);
                if (investimentoMov != null)
                {
                    oServico.Remover(investimentoMov);
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

        public bool AtualizarInvestimentoMov (int id,InvestimentoMov investimentoUpdate)
        {
            bool isUpdate = false;

            try
            {
                InvestimentoMov investimentoMov = ObterInvestimentoMovPorId(id);

                if (investimentoMov != null)
                {
                    oServico.Alterar(investimentoUpdate, id);
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