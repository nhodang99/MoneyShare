namespace MoneyShare.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    public IRepository<TEntity> Repository<TEntity>() where TEntity : class;

    Task<int> CommitAsync();
}
