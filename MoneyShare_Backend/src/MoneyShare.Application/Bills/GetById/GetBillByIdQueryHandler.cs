using AutoMapper;
using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Bills;
using SharedKernel;

namespace MoneyShare.Application.Bills.GetById;

internal sealed class GetBillByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetBillByIdQuery, BillDTO>
{
    public async Task<Result<BillDTO>> Handle(GetBillByIdQuery query, CancellationToken cancellationToken)
    {
        Bill? bill = await unitOfWork.Bills.SingleOrDefaultAsync(b => b.Id == query.BillId, cancellationToken);
        if (bill is null)
        {
            return Result.Failure<BillDTO>(BillErrors.NotFound(query.BillId));
        }

        return mapper.Map<BillDTO>(bill);
    }
}
