using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Entidade.Enum;
using ControleFinanceiro.Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFinanceiro.ServicosRest.Models
{
    public class CentroContabilModel: IDisposable
    {
        CentroContabilServico oServico;
        DbFinancaContext oFinancaContexto;

        public CentroContabilModel()
        {
            oFinancaContexto = new DbFinancaContext();
            oServico = new CentroContabilServico(oFinancaContexto);
        }

        public List<CentroContabil> ObterCentroContabil()
        {
            List<CentroContabil> oListaCentroContabil = oServico.Listar();
            return oListaCentroContabil;
        }

        public CentroContabil ObterCentroContabilPorId(int id)
        {
            return oServico.ObterPorId(id);
        }

        public bool CadastrarCentroContabil(CentroContabil centroContabil)
        {
            try
            {
                oServico.Adicionar(centroContabil);
                oServico.SalvarContexto();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool DeletarCentroContabil(int id)
        {
            bool isDeleted = false;

            try
            {
                CentroContabil centroContabil = ObterCentroContabilPorId(id);
                if (centroContabil != null)
                {
                    oServico.Remover(centroContabil);
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

        public bool AtualizarCentroContabil(int id, CentroContabil centroContabilUpdate)
        {
            bool isUpdate = false;

            try
            {
                CentroContabil centroCotanbil = ObterCentroContabilPorId(id);

                if (centroCotanbil != null)
                {
                    oServico.Alterar(centroContabilUpdate, id);
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