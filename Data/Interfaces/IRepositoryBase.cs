using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjetoNugets.Data.Interfaces
{
    public interface IRepositoryBase <TEntity> where TEntity:class
    {
        void Add(TEntity obj);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Save();
        //void Dispose();
    }
}
