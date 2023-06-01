using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.Data.Interfaces
{
    public interface IRepositoryBase <TEntity> where TEntity:class
    {
        void Add(TEntity obj);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Save();
        //void Dispose();
    }
}
