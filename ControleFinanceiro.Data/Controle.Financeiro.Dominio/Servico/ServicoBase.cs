namespace ControleFinanceiro.Dominio.Servico
{
    using ControleFinanceiro.Dominio.Interface;
    using ControleFinanceiro.Data.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EntityFramework.Extensions;
    using System.Data.Entity.Validation;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class
    {
        private DbFinancaContext oDbContexto;
        private bool oDisposed;

        public ServicoBase(DbFinancaContext dbContexto)
        {
            oDbContexto = dbContexto;
        }

        public List<TEntity> Listar()
        {
            return oDbContexto.Set<TEntity>().ToList();
        }

        public TEntity Adicionar(TEntity obj)
        {
            return oDbContexto.Set<TEntity>().Add(obj);
        }

        public void Adicionar(IEnumerable<TEntity> objs)
        {
            oDbContexto.Set<TEntity>().AddRange(objs);
        }

        public TEntity ObterPorId(int id)
        {
            return oDbContexto.Set<TEntity>().Find(id);
        }

        public void Alterar(TEntity obj, int id)
        {
            TEntity objOriginal = ObterPorId(id);
            oDbContexto.Entry(objOriginal).CurrentValues.SetValues(obj);
        }

        public void Alterar(TEntity objOld, TEntity objNew)
        {
            oDbContexto.Entry(objOld).CurrentValues.SetValues(objNew);
        }

        public void Remover(TEntity obj)
        {
            oDbContexto.Set<TEntity>().Remove(obj);
        }

        public void Remover(IEnumerable<TEntity> objs)
        {
            oDbContexto.Set<TEntity>().RemoveRange(objs);
        }

        public void SalvarContexto()
        {
            try
            {
                oDbContexto.SaveChanges();
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (oDisposed) return;

            if (disposing)
            {
                oDbContexto.Dispose();
            }
            oDisposed = true;
        }
    }
}
