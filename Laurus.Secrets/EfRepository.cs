using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Laurus.Secrets
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        public EfRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("DbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
            System.Diagnostics.Debug.WriteLine(DbContext.Database.Connection.ConnectionString);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            var entry = DbContext.Entry(entity);
            if (entry.State != System.Data.EntityState.Detached)
            {
                entry.State = System.Data.EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            var entry = DbContext.Entry(entity);
            if (entry.State == System.Data.EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            entry.State = System.Data.EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            var entry = DbContext.Entry(entity);
            if (entry.State != System.Data.EntityState.Deleted)
            {
                entry.State = System.Data.EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var x = GetById(id);
            if (x == null) return;
            Delete(x);
        }

        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }
    }
}