#region

using AutoMapper;
using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Groups.GetAll;

internal sealed class GetAllGroupsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetAllGroupsQuery, IEnumerable<GroupDto>>
{
    public async Task<Result<IEnumerable<GroupDto>>> Handle(GetAllGroupsQuery query,
        CancellationToken cancellationToken)
    {
        var groups = await unitOfWork.Groups.GetAllAsync(cancellationToken);

        return groups.Select(mapper.Map<GroupDto>).ToList();
    }
}