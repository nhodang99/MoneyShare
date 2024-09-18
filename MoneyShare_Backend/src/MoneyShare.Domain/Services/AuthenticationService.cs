using MoneyShare.Domain.Interfaces;
using MoneyShare.Domain.Users;
using MoneyShare.Domain.Users.Events;
using SharedKernel;

namespace MoneyShare.Domain.Services;

public class AuthenticationService(IUnitOfWork unitOfWork) : IAuthenticationService
{
    public async Task<Result<Guid>> Register(User user, CancellationToken cancellationToken)
    {
        user.RegisterDomainEvent(new UserRegisteredDomainEvent(user.Id));

        unitOfWork.Users.Add(user);

        await unitOfWork.CommitAsync(cancellationToken);

        return user.Id;
    }
}
