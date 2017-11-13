using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Data.Model;
using ControleFinanceiro.Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFinanceiro.ServicosRest.Models
{
    public class ContaContabilModel: IDisposable
    {
        DbFinancaContext oDbFinancaContext;
        ContaContabilServico oServico;

        public ContaContabilModel()
        {
            oDbFinancaContext = new DbFinancaContext();
            oServico = new ContaContabilServico(oDbFinancaContext);
        }

        public List<ContaContabil> ObterContaContabil()
        {
            List<ContaContabil> oListaContaContabil = oServico.Listar();
            return oListaContaContabil;
        }

        public ContaContabil ObterContaContabilPorId(int id)
        {
            return oServico.ObterPorId(id);
        }

        public bool CadastrarContaContabil(ContaContabil contaContabil)
        {
            try
            {
                oServico.Adicionar(contaContabil);
                oServico.SalvarContexto();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool DeletarContaContabil(int id)
        {
            bool isDeleted = false;

            try
            {
                ContaContabil contaContabil = ObterContaContabilPorId(id);
                if (contaContabil != null)
                {
                    oServico.Remover(contaContabil);
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

        public bool AtualizarContaContabil(int id, ContaContabil contaContabilUpdate)
        {
            bool isUpdate = false;

            try
            {
                ContaContabil contaContabil = ObterContaContabilPorId(id);

                if (contaContabil != null)
                {
                    oServico.Alterar(contaContabilUpdate, id);
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