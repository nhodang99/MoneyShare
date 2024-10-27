#region

using AutoMapper;
using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Bills;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Bills.GetById;

internal sealed class GetBillByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetBillByIdQuery, BillDto>
{
    public async Task<Result<BillDto>> Handle(GetBillByIdQuery query, CancellationToken cancellationToken)
    {
        var bill = await unitOfWork.Bills.SingleOrDefaultAsync(b => b.Id == query.BillId, cancellationToken);
        return bill is null
            ? Result.Failure<BillDto>(BillErrors.NotFound(query.BillId))
            : mapper.Map<BillDto>(bill);
    }
}