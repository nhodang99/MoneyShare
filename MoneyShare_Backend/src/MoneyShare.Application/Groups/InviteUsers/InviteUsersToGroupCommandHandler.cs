using MoneyShare.Application.Contracts.Messaging;
using SharedKernel;

namespace MoneyShare.Application.Groups.InviteUsers;

internal sealed class InviteUsersToGroupCommandHandler : ICommandHandler<InviteUsersToGroupCommand>
{
    public Task<Result> Handle(InviteUsersToGroupCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
