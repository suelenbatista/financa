using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Dominio.Servico;
using ControleFinanceiro.Entidade.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFinanceiro.ServicosRest.Models
{
    public class MovimentoRateioModel : IDisposable
    {
         DbFinancaContext oDbFinancaContext;
         MovimentoRateioServico oServico;

        public MovimentoRateioModel()
        {
            oDbFinancaContext = new DbFinancaContext();
            oServico = new MovimentoRateioServico(oDbFinancaContext);
        }

        public List<MovimentoRateio> ObterMovimentoRateio()
        {
            List<MovimentoRateio> oListaMovimentoRateio = oServico.Listar();
            return oListaMovimentoRateio;
        }

        public MovimentoRateio ObterMovimentoRateioPorId(int id)
        {
            return oServico.ObterPorId(id);
        }

        public bool CadastrarMovimentoRateio(MovimentoRateio MovimentoRateio)
        {
            try
            {
                oServico.Adicionar(MovimentoRateio);
                oServico.SalvarContexto();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool DeletarMovimentoRateio(int id)
        {
            bool isDeleted = false;

            try
            {
                MovimentoRateio MovimentoRateio = ObterMovimentoRateioPorId(id);
                if (MovimentoRateio != null)
                {
                    oServico.Remover(MovimentoRateio);
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

        public bool AtualizarMovimentoRateio(int id, MovimentoRateio MovimentoRateioUpdate)
        {
            bool isUpdate = false;

            try
            {
                MovimentoRateio MovimentoRateio = ObterMovimentoRateioPorId(id);

                if (MovimentoRateio != null)
                {
                    oServico.Alterar(MovimentoRateioUpdate, id);
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