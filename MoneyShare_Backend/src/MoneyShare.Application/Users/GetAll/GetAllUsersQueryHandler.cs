#region

using AutoMapper;
using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Users.GetAll;

internal sealed class GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetAllUsersQuery, List<UserDto>>
{
    public async Task<Result<List<UserDto>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        var users = await unitOfWork.Users.GetAllAsync(cancellationToken);

        return users.Select(mapper.Map<UserDto>).ToList();
    }
}