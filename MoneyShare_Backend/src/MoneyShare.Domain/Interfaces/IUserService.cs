using MoneyShare.Domain.Users;
using SharedKernel;

namespace MoneyShare.Domain.Interfaces;

public interface IUserService
{
    Task<Result> DeleteUser(Guid userId, CancellationToken cancellationToken);
    Task<Result> EditUser(User user, CancellationToken cancellationToken);
}
