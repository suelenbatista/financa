using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Dominio.Servico;
using ControleFinanceiro.Entidade.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFinanceiro.ServicosRest.Models
{
    public class ContaBancariaModel: IDisposable
    {
        ContaBancariaServico oServico;
        DbFinancaContext oFinancaContexto;

        public ContaBancariaModel()
        {
            oFinancaContexto = new DbFinancaContext();
            oServico = new ContaBancariaServico(oFinancaContexto);
        }

        public List<ContaBancaria> ObterContaBancaria()
        {
            List<ContaBancaria> oListaContaBancaria = oServico.Listar();
            return oListaContaBancaria;
        }

        public ContaBancaria ObterContaBancariaPorId(int id)
        {
            return oServico.ObterPorId(id);
        }

        public bool CadastrarContaBancaria(ContaBancaria ContaBancaria)
        {
            try
            {
                oServico.Adicionar(ContaBancaria);
                oServico.SalvarContexto();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool DeletarContaBancaria(int id)
        {
            bool isDeleted = false;

            try
            {
                ContaBancaria ContaBancaria = ObterContaBancariaPorId(id);
                if (ContaBancaria != null)
                {
                    oServico.Remover(ContaBancaria);
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

        public bool AtualizarContaBancaria(int id, ContaBancaria ContaBancariaUpdate)
        {
            bool isUpdate = false;

            try
            {
                ContaBancaria contaBancaria = ObterContaBancariaPorId(id);

                if (contaBancaria != null)
                {
                    oServico.Alterar(ContaBancariaUpdate, id);
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
            oFinancaContexto.Dispose();
        }
    }
}