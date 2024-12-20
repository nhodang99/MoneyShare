﻿#region

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoneyShare.Domain.Repositories;
using SharedKernel;

#endregion

namespace MoneyShare.Infrastructure.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext Context;

    protected Repository(DbContext context)
    {
        Context = context;
    }

    /// <summary>
    /// Return a tracked entity, optimized for ID resolution
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Context.Set<TEntity>().FindAsync(new object?[] { id, cancellationToken }, cancellationToken);
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

        return await query.SingleOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken,
        bool tracking = false)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(predicate, cancellationToken);
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
        var enumerable = entities as TEntity[] ?? entities.ToArray();
        foreach (var entity in enumerable)
        {
            if (entity is AuditEntity auditEntity)
            {
                auditEntity.CreatedDate = DateTime.UtcNow;
            }
        }

        Context.Set<TEntity>().AddRange(enumerable);
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
        var enumerable = entities as TEntity[] ?? entities.ToArray();
        foreach (TEntity entity in enumerable)
        {
            if (entity is DeleteEntity deleteEntity)
            {
                deleteEntity.IsDeleted = true;
            }
        }

        Context.Set<TEntity>().RemoveRange(enumerable);
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