using AutoMapper;
using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain;
using SharedKernel;

namespace MoneyShare.Application.Bills.GetBillsInGroup;

internal sealed class GetBillsInGroupQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IQueryHandler<GetBillsInGroupQuery, IEnumerable<BillDTO>>
{
    public async Task<Result<IEnumerable<BillDTO>>> Handle(GetBillsInGroupQuery query, CancellationToken cancellationToken)
    {
        var bills = await unitOfWork.Bills.GetBillsInGroupAsync(query.GroupId, query.PageIndex, query.PageSize, cancellationToken);

        List<BillDTO> billDtos = [];

        foreach (var bill in bills)
        {
            billDtos.Add(mapper.Map<BillDTO>(bill));
        }

        return billDtos;
    }
}
