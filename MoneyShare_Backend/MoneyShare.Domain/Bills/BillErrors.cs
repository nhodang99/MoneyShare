using SharedKernel;

namespace MoneyShare.Domain.Bills;

public static class BillErrors
{
    public static Error NotFound(Guid billId) => Error.NotFound(
        "Bill.NotFound",
        $"The bill with the Id = '{billId}' was not found");
}
