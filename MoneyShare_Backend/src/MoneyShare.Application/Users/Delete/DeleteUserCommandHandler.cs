#region

using MoneyShare.Application.Interfaces.Authentication;
using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain.Interfaces;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Users.Delete;

internal class DeleteUserCommandHandler(IUserDomainService userService, IIdentityService identityService)
    : ICommandHandler<DeleteUserCommand>
{
    public async Task<Result> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        // @TODO delete applicationUser, logout: here or in domain event handler
        return await userService.DeleteUserAsync(command.UserId, cancellationToken);
    }
}