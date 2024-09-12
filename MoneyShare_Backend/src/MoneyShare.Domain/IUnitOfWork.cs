using MoneyShare.Domain.Repositories;

namespace MoneyShare.Domain;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users {  get; }
    IBillRepository Bills { get; }
    IGroupRepository Groups { get; }

    Task<int> CommitAsync(CancellationToken cancellationToken);
}
