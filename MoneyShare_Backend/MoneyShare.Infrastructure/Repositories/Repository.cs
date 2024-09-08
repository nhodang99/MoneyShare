using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoneyShare.Domain.Repositories;
using SharedKernel;
using System.Linq.Expressions;

namespace MoneyShare.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext Context;

    public Repository(DbContext context)
    {
        Context = context;
    }

    public async Task<TEntity?> GetAsync(Guid id)
    {
        if (typeof(IBaseEntity).IsAssignableFrom(typeof(TEntity)))
        {
            return await Context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => ((IBaseEntity)e).Id == id);
        }
        return default;
    }

    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Context.Set<TEntity>()
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();
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
