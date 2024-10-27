#region

using AutoMapper;
using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Groups;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Groups.GetById;

internal class GetGroupByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetGroupByIdQuery, GroupDto>
{
    public async Task<Result<GroupDto>> Handle(GetGroupByIdQuery query, CancellationToken cancellationToken)
    {
        var group = await unitOfWork.Groups.SingleOrDefaultAsync(g => g.Id == query.Id, cancellationToken);
        return group is null
            ? Result.Failure<GroupDto>(GroupErrors.NotFound(query.Id))
            : mapper.Map<GroupDto>(group);
    }
}