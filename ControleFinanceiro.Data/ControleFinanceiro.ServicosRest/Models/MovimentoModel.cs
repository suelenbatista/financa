using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Dominio.Servico;
using ControleFinanceiro.Entidade.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFinanceiro.ServicosRest.Models
{
    public class MovimentoModel : IDisposable
    {
        DbFinancaContext oDbFinancaContext;
        MovimentoServico oServico;

        public MovimentoModel()
        {
            oDbFinancaContext = new DbFinancaContext();
            oServico = new MovimentoServico(oDbFinancaContext);
        }

        public List<Movimento> ObterMovimento()
        {
            List<Movimento> oListaMovimento = oServico.Listar();
            return oListaMovimento;
        }

        public Movimento ObterMovimentoPorId(int id)
        {
            return oServico.ObterPorId(id);
        }

        public bool CadastrarMovimento(Movimento Movimento)
        {
            try
            {
                oServico.Adicionar(Movimento);
                oServico.SalvarContexto();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool DeletarMovimento(int id)
        {
            bool isDeleted = false;

            try
            {
                Movimento Movimento = ObterMovimentoPorId(id);
                if (Movimento != null)
                {
                    oServico.Remover(Movimento);
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

        public bool AtualizarMovimento(int id, Movimento MovimentoUpdate)
        {
            bool isUpdate = false;

            try
            {
                Movimento Movimento = ObterMovimentoPorId(id);

                if (Movimento != null)
                {
                    oServico.Alterar(MovimentoUpdate, id);
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