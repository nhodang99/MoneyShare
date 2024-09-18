using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain.Interfaces;
using SharedKernel;

namespace MoneyShare.Application.Groups.Delete;

internal class DeleteGroupCommandHandler(IGroupService groupService) : ICommandHandler<DeleteGroupCommand>
{
    public async Task<Result> Handle(DeleteGroupCommand command, CancellationToken cancellationToken)
    {
        return await groupService.DeleteGroup(command.GroupId, cancellationToken);
    }
}
