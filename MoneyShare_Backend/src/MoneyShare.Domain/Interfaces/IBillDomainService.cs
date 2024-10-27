using MoneyShare.Domain.Bills;
using SharedKernel;

namespace MoneyShare.Domain.Interfaces;

public interface IBillDomainService
{
    Task<Result> DeleteBillAsync(Guid billId, CancellationToken cancellationToken);
    Task<Result> EditBillAsync(Bill bill, CancellationToken cancellationToken);
    Task<Result> CompleteBillAsync(Guid billId, CancellationToken cancellationToken);
}
