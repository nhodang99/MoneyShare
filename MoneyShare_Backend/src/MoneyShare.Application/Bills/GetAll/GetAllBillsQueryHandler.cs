using AutoMapper;
using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain;
using SharedKernel;

namespace MoneyShare.Application.Bills.GetAll;

internal sealed class GetAllBillsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetAllBillsQuery, IEnumerable<BillDTO>>
{
    public async Task<Result<IEnumerable<BillDTO>>> Handle(GetAllBillsQuery query, CancellationToken cancellationToken)
    {
        var groups = await unitOfWork.Bills.GetAllAsync(cancellationToken);

        List<BillDTO> groupDtos = [];
        foreach (var group in groups)
        {
            groupDtos.Add(mapper.Map<BillDTO>(group));
        }
        return groupDtos.ToList();
    }
}
