using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TourneyTracker
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private TourneyTrackerDBEntities context;
        private DbSet<TEntity> dbSet;

        public GenericRepository(TourneyTrackerDBEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> All()
        {
            return dbSet;
        }

        public virtual TEntity Find(int id)
        {
            return dbSet.Find(id);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void InsertAndSave(TEntity entity)
        {
            Insert(entity);
            Save();
        }

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
