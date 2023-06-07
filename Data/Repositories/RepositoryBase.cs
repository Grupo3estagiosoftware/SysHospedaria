using Microsoft.EntityFrameworkCore;
using ProjetoNugets.Data.Interfaces;
using ProjetoNugets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjetoNugets.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
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
            //var data = dbSet?.Where(s => s.Id == id).AsNoTracking().SingleOrDefault();
            //return data ?? default;

            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();

            //return _db.Set<TEntity>().ToList();
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
            //dbSet.Remove(obj);
            dbSet.Update(obj);

           // _db.Entry(obj).State = EntityState.Detached;  
            //_db.Entry(obj).Property("Nome").IsModified = true;
            //dbSet.Attach(obj);
            //_db.Entry(obj).State = EntityState.Modified;
            //dbSet.Update(obj);
            //_db.Set<TEntity>().Update(obj);
            _db.SaveChanges();
           
        }
    }
}
