using AutoMapper;
using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Groups;
using SharedKernel;

namespace MoneyShare.Application.Groups.GetById;

internal class GetGroupByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetGroupByIdQuery, GroupDTO>
{
    public async Task<Result<GroupDTO>> Handle(GetGroupByIdQuery query, CancellationToken cancellationToken)
    {
        Group? group = await unitOfWork.Groups.SingleOrDefaultAsync(g => g.Id == query.Id, cancellationToken);
        if (group is null)
        {
            return Result.Failure<GroupDTO>(GroupErrors.NotFound(query.Id));
        }

        return mapper.Map<GroupDTO>(group);
    }
}
