using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoneyShare.Domain.Repositories;
using SharedKernel;
using System.Linq.Expressions;

namespace MoneyShare.Infrastructure.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext Context;

    public Repository(DbContext context)
    {
        Context = context;
    }

    /// <summary>
    /// Return a tracked entity, optimized for ID resolution
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Context.Set<TEntity>().FindAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken,
        bool tracking = false)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);

        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken, bool tracking = false)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken,
        bool tracking = false)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity,bool>> predicate,
        CancellationToken cancellationToken,
        bool tracking = false)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await Context.Set<TEntity>().AnyAsync(predicate, cancellationToken);
    }

    public void Add(TEntity entity)
    {
        if (entity is AuditEntity auditEntity)
        {
            auditEntity.CreatedDate = DateTime.UtcNow;
        }
        Context.Set<TEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity is AuditEntity auditEntity)
            {
                auditEntity.CreatedDate = DateTime.UtcNow;
            }
        }
        Context.Set<TEntity>().AddRange(entities);
    }

    public void Remove(TEntity entity)
    {
        if (entity is DeleteEntity deleteEntity)
        {
            deleteEntity.IsDeleted = true;
        }
        Context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        foreach (TEntity entity in entities)
        {
            if (entity is DeleteEntity deleteEntity)
            {
                deleteEntity.IsDeleted = true;
            }
        }
        Context.Set<TEntity>().RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        if (entity is AuditEntity auditEntity)
        {
            auditEntity.UpdatedDate = DateTime.UtcNow;
        }
        Context.Set<TEntity>().Update(entity);
    }

    public EntityEntry Entry(TEntity entity)
    {
        return Context.Entry(entity);
    }
}
