using MoneyShare.Domain.Groups;
using SharedKernel;

namespace MoneyShare.Domain.Interfaces;

public interface IGroupService
{
    Task<Result> DeleteGroup(Guid groupId, CancellationToken cancellationToken);
    Task<Result> EditGroup(Group group, CancellationToken cancellationToken);
}
