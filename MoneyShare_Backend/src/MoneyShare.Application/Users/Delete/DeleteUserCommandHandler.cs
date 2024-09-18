using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain.Interfaces;
using SharedKernel;

namespace MoneyShare.Application.Users.Delete;

internal class DeleteUserCommandHandler(IUserService userService) : ICommandHandler<DeleteUserCommand>
{
    public async Task<Result> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        return await userService.DeleteUser(command.UserId, cancellationToken);
    }
}
