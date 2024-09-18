using SharedKernel;

namespace MoneyShare.Domain.Bills;

public static class BillErrors
{
    public static Error NotFound(Guid billId) => Error.NotFound(
        "Bill.NotFound",
        $"The bill with the Id = '{billId}' was not found");

    public static Error GroupNotFound(Guid groupId) => Error.NotFound(
    "Bill.Create.GroupNotFound",
    $"No group with the Id = '{groupId}' that specified in the Bill creating request was found");

    public static Error PayerNotFound(Guid payerId) => Error.NotFound(
        "Bill.Create.UserNotFound",
        $"No user with the Id = '{payerId}' that specified in the Bill creating request was found");
}
