using Microsoft.Extensions.Logging;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Domain.Users.Events;
using MoneyShare.Domain.Users;
using SharedKernel;

namespace MoneyShare.Domain.Services;

public class BillService(IUnitOfWork unitOfWork, ILogger<BillService> logger) : IBillService
{
    public async Task<Result> CompleteBill(Guid billId, CancellationToken cancellationToken)
    {
        Bill? bill = await unitOfWork.Bills.SingleOrDefaultAsync(b => b.Id == billId, cancellationToken);

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
        // TODO: Updated by

        //bill.RegisterDomainEvent(new BillCompletedDomainEvent(billId));

        await unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> DeleteBill(Guid billId, CancellationToken cancellationToken)
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

    public async Task<Result> EditBill(Bill bill, CancellationToken cancellationToken)
    {
        logger.LogDebug("Editing bill id {bill.Id}", bill.Id);

        unitOfWork.Bills.Update(bill);
        //group.RegisterDomainEvent(new UserEditedDomainEvent(group.Id));

        await unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}
