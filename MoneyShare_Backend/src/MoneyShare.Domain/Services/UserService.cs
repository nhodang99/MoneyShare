using Microsoft.Extensions.Logging;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Domain.Users;
using MoneyShare.Domain.Users.Events;
using SharedKernel;

namespace MoneyShare.Domain.Services;

public class UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger) : IUserService
{
    public async Task<Result> DeleteUser(Guid userId, CancellationToken cancellationToken)
    {
        User? user = await unitOfWork.Users.GetByIdAsync(userId, cancellationToken);
        if (user is null)
        {
            return Result.Failure(UserErrors.NotFound(userId));
        }

        logger.LogDebug("Deleting user id {userId}", userId);
        unitOfWork.Users.Remove(user);
        user.RegisterDomainEvent(new UserDeletedDomainEvent(userId));

        await unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> EditUser(User user, CancellationToken cancellationToken)
    {
        logger.LogDebug("Editing user id {user.Id}", user.Id);

        unitOfWork.Users.Update(user);
        user.RegisterDomainEvent(new UserEditedDomainEvent(user.Id));

        await unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}
