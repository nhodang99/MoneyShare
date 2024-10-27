#region

using AutoMapper;
using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Bills.GetAll;

internal sealed class GetAllBillsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetAllBillsQuery, IEnumerable<BillDto>>
{
    public async Task<Result<IEnumerable<BillDto>>> Handle(GetAllBillsQuery query, CancellationToken cancellationToken)
    {
        var groups = await unitOfWork.Bills.GetAllAsync(cancellationToken);

        return groups.Select(mapper.Map<BillDto>).ToList();
    }
}