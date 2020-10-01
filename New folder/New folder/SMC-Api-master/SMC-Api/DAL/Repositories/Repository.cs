using SMC_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SMC_Api.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SMC_DBEntities Context;
        protected readonly IDbSet<TEntity> dbSet;
        public Repository(SMC_DBEntities context)
        {
            Context = context;
        }
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Add(TEntity entity)
        {

            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
            Context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            Context.SaveChanges();
        }

        public IEnumerable<TEntity> ExecWithStoreProcedure(string query)
        {
            return Context.Database.SqlQuery<TEntity>(query);
        }
    }
}