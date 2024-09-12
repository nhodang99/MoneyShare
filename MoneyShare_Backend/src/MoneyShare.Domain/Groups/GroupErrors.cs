using SharedKernel;

namespace MoneyShare.Domain.Groups;

public static class GroupErrors
{
    public static Error NotFound(Guid groupId) => Error.NotFound(
        "Group.NotFound",
        $"The group with the Id = '{groupId}' was not found");
}
