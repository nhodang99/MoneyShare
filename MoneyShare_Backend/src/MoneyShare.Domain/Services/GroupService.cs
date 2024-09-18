using Microsoft.Extensions.Logging;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Interfaces;
using SharedKernel;

namespace MoneyShare.Domain.Services;

public class GroupService(IUnitOfWork unitOfWork, ILogger<GroupService> logger) : IGroupService
{
    public async Task<Result> DeleteGroup(Guid groupId, CancellationToken cancellationToken)
    {
        Group? group = await unitOfWork.Groups.GetByIdAsync(groupId, cancellationToken);
        if (group is null)
        {
            return Result.Failure(GroupErrors.NotFound(groupId));
        }

        logger.LogDebug("Deleting group id {groupId}", groupId);
        unitOfWork.Groups.Remove(group);
        //group.RegisterDomainEvent(new UserDeletedDomainEvent(groupId));

        await unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> EditGroup(Group group, CancellationToken cancellationToken)
    {
        logger.LogDebug("Editing group id {group.Id}", group.Id);

        unitOfWork.Groups.Update(group);
        //group.RegisterDomainEvent(new UserEditedDomainEvent(group.Id));

        await unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}
