namespace ControleFinanceiro.Dominio.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IServicoBase<TEntity> where TEntity : class
    {
        List<TEntity> Listar();
        TEntity Adicionar(TEntity obj);
        void Adicionar(IEnumerable<TEntity> objs);
        TEntity ObterPorId(int id);
        void Alterar(TEntity obj, int id);
        void Alterar(TEntity objOld, TEntity objNew);
        void Remover(TEntity obj);
        void Remover(IEnumerable<TEntity> objs);
        void SalvarContexto();
    }
}
