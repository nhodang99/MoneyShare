using MoneyShare.Domain.Repositories;
using MoneyShare.Infrastructure.Database;

namespace MoneyShare.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    private Dictionary<string, object> Repositories { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        Repositories = new Dictionary<string, dynamic>();
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    // Get repository for an entity
    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        var typeName = typeof(TEntity).Name;

        lock (Repositories)
        {
            if (Repositories.TryGetValue(typeName, out object? value))
            {
                return (IRepository<TEntity>)value;
            }

            var repository = new Repository<TEntity>(_context);

            Repositories.Add(typeName, repository);
            return repository;
        }
    }
}
