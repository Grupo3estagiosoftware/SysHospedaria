using Microsoft.EntityFrameworkCore;
using ProjetoNugets.Data.Interfaces;
using ProjetoNugets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.Data.Repositories
{
    public class RepositoryBase<TEntity> : /*IDisposable,*/ IRepositoryBase<TEntity> where TEntity : class
    {
       private readonly AppDbContext _db;
        internal DbSet<TEntity> dbSet;

        public RepositoryBase(AppDbContext db)
        {
            _db = db;
            this.dbSet = db.Set<TEntity>();
        }
        public void Add(TEntity obj)
        {
            dbSet.Add(obj);
            _db.SaveChanges();
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        public TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
           return _db.Set<TEntity>().ToList();
        }

        public void Remove(int id)
        {
            TEntity entity = dbSet.Find(id);
            dbSet.Remove(entity);
            _db.SaveChanges();
        }
        public void Remove(TEntity obj)
        {
            dbSet.Remove(obj);
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            //_db.Entry(obj).Property("Descricao").IsModified = true;
            //_db.Entry<TEntity>(obj).State = EntityState.Modified; 
            
            //dbSet.Update(obj);
            _db.Update(obj);
            _db.SaveChanges();
           
        }
    }
}
