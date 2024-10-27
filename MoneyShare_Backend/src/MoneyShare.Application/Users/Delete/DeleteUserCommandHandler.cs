#region

using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain.Interfaces;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Users.Delete;

internal class DeleteUserCommandHandler(IUserDomainService userService) : ICommandHandler<DeleteUserCommand>
{
    public async Task<Result> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        return await userService.DeleteUserAsync(command.UserId, cancellationToken);
    }
}