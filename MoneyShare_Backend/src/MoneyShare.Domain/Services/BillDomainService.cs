#region

using Microsoft.Extensions.Logging;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Interfaces;
using SharedKernel;

#endregion

namespace MoneyShare.Domain.Services;

public class BillDomainService(IUnitOfWork unitOfWork, ILogger<BillDomainService> logger) : IBillDomainService
{
    public async Task<Result> CompleteBillAsync(Guid billId, CancellationToken cancellationToken)
    {
        var bill = await unitOfWork.Bills.SingleOrDefaultAsync(b => b.Id == billId, cancellationToken);

        if (bill is null)
        {
            return Result.Failure(BillErrors.NotFound(billId));
        }

        if (bill.Status == BillStatus.Completed)
        {
            throw new Exception("Invalid bill status");
        }

        bill.Status = BillStatus.Completed;
        bill.UpdatedDate = DateTime.UtcNow;
        // @TODO: Updated by

        //bill.RegisterDomainEvent(new BillCompletedDomainEvent(billId));

        await unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> DeleteBillAsync(Guid billId, CancellationToken cancellationToken)
    {
        Bill? bill = await unitOfWork.Bills.GetByIdAsync(billId, cancellationToken);
        if (bill is null)
        {
            return Result.Failure(BillErrors.NotFound(billId));
        }

        logger.LogDebug("Deleting bill id {billId}", billId);
        unitOfWork.Bills.Remove(bill);
        //user.RegisterDomainEvent(new BillDeletedDomainEvent(billId));

        await unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> EditBillAsync(Bill bill, CancellationToken cancellationToken)
    {
        logger.LogDebug("Editing bill id {bill.Id}", bill.Id);

        unitOfWork.Bills.Update(bill);
        //group.RegisterDomainEvent(new UserEditedDomainEvent(group.Id));

        await unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}