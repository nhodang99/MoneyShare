using MoneyShare.Domain;
using MoneyShare.Domain.Repositories;
using MoneyShare.Infrastructure.Database;
using MoneyShare.Infrastructure.Repositories;

namespace MoneyShare.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IUserRepository Users { get; private set; }
    public IBillRepository Bills { get; private set; }
    public IGroupRepository Groups { get; private set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        Users = new UserRepository(_context);
        Bills = new BillRepository(_context);
        Groups = new GroupRepository(_context);
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
