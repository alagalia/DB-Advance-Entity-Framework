using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EntityFramework.Extensions;
using PhotoShare.Data.Intefaces;

namespace PhotoShare.Data.Repositories
{
    public class Repository<TEntity> :IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> dbSet;

        public Repository(DbSet<TEntity> dbset)
        {
            this.dbSet = dbset;
        }


        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                this.dbSet.Add(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            this.dbSet.RemoveRange(entities);
            //this.dbSet.Delete(entities.AsQueryable());
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.dbSet;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }

        public TEntity FirstOrDefault()
        {
            return this.dbSet.FirstOrDefault();
        }

        public TEntity FirstOrDefaultWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbSet.FirstOrDefault(predicate);
        }
    }
}