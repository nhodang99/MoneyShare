using MoneyShare.Domain.Groups;
using SharedKernel;

namespace MoneyShare.Domain.Interfaces;

public interface IGroupDomainService
{
    Task<Result> DeleteGroupAsync(Guid groupId, CancellationToken cancellationToken);
    Task<Result> EditGroupAsync(Group group, CancellationToken cancellationToken);
}
