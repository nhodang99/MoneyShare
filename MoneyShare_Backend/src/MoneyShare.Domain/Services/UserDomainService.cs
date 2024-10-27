using Microsoft.Extensions.Logging;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Domain.Users;
using MoneyShare.Domain.Users.Events;
using SharedKernel;

namespace MoneyShare.Domain.Services;

public class UserDomainService(IUnitOfWork unitOfWork, ILogger<UserDomainService> logger) : IUserDomainService
{
    public async Task<Result<Guid>> AddUserAsync(User user, CancellationToken cancellationToken)
    {
        user.RegisterDomainEvent(new UserRegisteredDomainEvent(user.Id));

        unitOfWork.Users.Add(user);

        await unitOfWork.CommitAsync(cancellationToken);

        return user.Id;
    }
    public async Task<Result> DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
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

    public async Task<Result> EditUserAsync(User user, CancellationToken cancellationToken)
    {
        logger.LogDebug("Editing user id {user.Id}", user.Id);

        unitOfWork.Users.Update(user);
        user.RegisterDomainEvent(new UserEditedDomainEvent(user.Id));

        await unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}
