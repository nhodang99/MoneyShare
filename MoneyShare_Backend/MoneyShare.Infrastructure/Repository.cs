using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoneyShare.Domain.Base;
using MoneyShare.Domain.Interfaces;
using System.Linq.Expressions;

namespace MoneyShare.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IAuditEntity)entity).CreatedDate = DateTime.UtcNow;
            }
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (typeof(IAuditEntity).IsAssignableFrom(typeof(TEntity)))
                {
                    ((IAuditEntity)entity).CreatedDate = DateTime.UtcNow;
                }
            }
            Context.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return [.. Context.Set<TEntity>()];
        }

        public void Remove(TEntity entity)
        {
            if (typeof(IDeleteEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IDeleteEntity)entity).IsDeleted = true;
            }
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                if (typeof(IDeleteEntity).IsAssignableFrom(typeof(TEntity)))
                {
                    ((IDeleteEntity)entity).IsDeleted = true;
                }
            }
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(TEntity)))
            {
                ((IAuditEntity)entity).UpdatedDate = DateTime.UtcNow;
            }
            Context.Set<TEntity>().Update(entity);
        }

        public EntityEntry GetEntry(TEntity entity)
        {
            return Context.Entry(entity);
        }
    }
}
