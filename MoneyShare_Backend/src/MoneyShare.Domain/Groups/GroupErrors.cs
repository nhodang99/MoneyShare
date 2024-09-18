using SharedKernel;

namespace MoneyShare.Domain.Groups;

public static class GroupErrors
{
    public static Error NotFound(Guid groupId) => Error.NotFound(
        "Group.NotFound",
        $"The group with the Id = '{groupId}' was not found");

    public static Error Existed(string name) => Error.Conflict(
        "Group.Existed",
        $"The group name '{name}' already existed");
}
