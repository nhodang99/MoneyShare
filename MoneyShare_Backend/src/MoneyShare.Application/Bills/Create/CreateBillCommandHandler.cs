using AutoMapper;
using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Bills;
using SharedKernel;

namespace MoneyShare.Application.Bills.Create;

internal sealed class CreateBillCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<CreateBillCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateBillCommand command, CancellationToken cancellationToken)
    {
        if (!await unitOfWork.Groups.AnyAsync(g => g.Id == command.GroupId, cancellationToken))
        {
            return Result.Failure<Guid>(BillErrors.GroupNotFound(command.GroupId));
        }

        if (!await unitOfWork.Users.AnyAsync(g => g.Id == command.PayerId, cancellationToken))
        {
            return Result.Failure<Guid>(BillErrors.PayerNotFound(command.PayerId));
        }

        Bill bill = mapper.Map<Bill>(command);
        bill.Id = Guid.NewGuid();
        bill.Status = BillStatus.Pending;

        unitOfWork.Bills.Add(bill);
        await unitOfWork.CommitAsync(cancellationToken);

        return bill.Id;
    }
}
