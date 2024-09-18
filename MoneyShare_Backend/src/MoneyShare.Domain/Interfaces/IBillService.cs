using MoneyShare.Domain.Bills;
using SharedKernel;

namespace MoneyShare.Domain.Interfaces;

public interface IBillService
{
    Task<Result> DeleteBill(Guid billId, CancellationToken cancellationToken);
    Task<Result> EditBill(Bill bill, CancellationToken cancellationToken);
    Task<Result> CompleteBill(Guid billId, CancellationToken cancellationToken);
}
