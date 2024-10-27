#region

using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain.Interfaces;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Groups.Delete;

internal class DeleteGroupCommandHandler(IGroupDomainService groupService) : ICommandHandler<DeleteGroupCommand>
{
    public async Task<Result> Handle(DeleteGroupCommand command, CancellationToken cancellationToken)
    {
        return await groupService.DeleteGroupAsync(command.GroupId, cancellationToken);
    }
}