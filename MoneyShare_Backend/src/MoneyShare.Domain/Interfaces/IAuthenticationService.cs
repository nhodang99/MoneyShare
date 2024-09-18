using MoneyShare.Domain.Users;
using SharedKernel;

namespace MoneyShare.Domain.Interfaces;

public interface IAuthenticationService
{
    Task<Result<Guid>> Register(User user, CancellationToken cancellationToken);
}
