using MoneyShare.Domain.Users;
using SharedKernel;

namespace MoneyShare.Domain.Interfaces;

public interface IUserDomainService
{
    Task<Result<Guid>> AddUserAsync(User user, CancellationToken cancellationToken);
    Task<Result> DeleteUserAsync(Guid userId, CancellationToken cancellationToken);
    Task<Result> EditUserAsync(User user, CancellationToken cancellationToken);
}
