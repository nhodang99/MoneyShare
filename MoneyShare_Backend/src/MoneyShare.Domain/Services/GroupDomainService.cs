﻿using Microsoft.Extensions.Logging;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Interfaces;
using SharedKernel;

namespace MoneyShare.Domain.Services;

public class GroupDomainService(IUnitOfWork unitOfWork, ILogger<GroupDomainService> logger) : IGroupDomainService
{
    public async Task<Result> DeleteGroupAsync(Guid groupId, CancellationToken cancellationToken)
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

    public async Task<Result> EditGroupAsync(Group group, CancellationToken cancellationToken)
    {
        logger.LogDebug("Editing group id {group.Id}", group.Id);

        unitOfWork.Groups.Update(group);
        //group.RegisterDomainEvent(new UserEditedDomainEvent(group.Id));

        await unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}
