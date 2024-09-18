using MoneyShare.Application.Contracts.Messaging;
using SharedKernel;

namespace MoneyShare.Application.Groups.RemoveUsers;

internal class RemoveUsersFromGroupCommandHandler : ICommandHandler<RemoveUsersFromGroupCommand>
{
    public Task<Result> Handle(RemoveUsersFromGroupCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
