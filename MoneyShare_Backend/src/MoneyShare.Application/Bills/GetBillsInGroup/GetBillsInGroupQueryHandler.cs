#region

using AutoMapper;
using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Bills.GetBillsInGroup;

internal sealed class GetBillsInGroupQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetBillsInGroupQuery, IEnumerable<BillDto>>
{
    public async Task<Result<IEnumerable<BillDto>>> Handle(GetBillsInGroupQuery query,
        CancellationToken cancellationToken)
    {
        var bills = await unitOfWork.Bills.GetBillsInGroupAsync(query.GroupId, query.PageIndex, query.PageSize,
            cancellationToken);

        return bills.Select(mapper.Map<BillDto>).ToList();
    }
}