using AutoMapper;
using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain;
using SharedKernel;

namespace MoneyShare.Application.Groups.GetAll;

internal sealed class GetAllGroupsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetAllGroupsQuery, IEnumerable<GroupDTO>>
{
    public async Task<Result<IEnumerable<GroupDTO>>> Handle(GetAllGroupsQuery query, CancellationToken cancellationToken)
    {
        var groups = await unitOfWork.Groups.GetAllAsync(cancellationToken);

        List<GroupDTO> groupDtos = [];
        foreach (var group in groups)
        {
            groupDtos.Add(mapper.Map<GroupDTO>(group));
        }
        return groupDtos.ToList();
    }
}
