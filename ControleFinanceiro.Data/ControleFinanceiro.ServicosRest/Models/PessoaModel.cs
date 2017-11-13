using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Data.Model;
using ControleFinanceiro.Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFinanceiro.ServicosRest.Models
{

    public class PessoaModel : IDisposable
    {
        PessoaServico oServico;
        DbFinancaContext oFinancaContexto;

        public PessoaModel()
        {
            oFinancaContexto = new DbFinancaContext();
            oServico = new PessoaServico(oFinancaContexto);
        }

        public List<Pessoa> ObterPessoas()
        {
            List<Pessoa> oListaPessoa = oServico.Listar();            
            return oListaPessoa;
        }

        public Pessoa ObterPessoaPorId(int id)
        {
            return oServico.ObterPorId(id);
        }

        public bool CadastrarPessoa(Pessoa pessoa)
        {
            try
            {
                oServico.Adicionar(pessoa);
                oServico.SalvarContexto();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool DeletarPessoa(int id)
        {
            bool isDeleted = false;

            try
            {
                Pessoa pessoa = ObterPessoaPorId(id);
                if (pessoa != null)
                {
                    oServico.Remover(pessoa);
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

        public bool AtualizarPessoa(int id, Pessoa pessoaUpdate)
        {
            bool isUpdate = false;

            try
            {
                Pessoa pessoa = ObterPessoaPorId(id);

                if (pessoa != null)
                {
                    oServico.Alterar(pessoaUpdate, id);
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