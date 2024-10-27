#region

using AutoMapper;
using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Users;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Users.GetById;

internal sealed class GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetUserByIdQuery, UserDto>
{
    public async Task<Result<UserDto>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.SingleOrDefaultAsync(u => u.Id == query.UserId, cancellationToken);
        return user is null
            ? Result.Failure<UserDto>(UserErrors.NotFoundByEmail)
            : mapper.Map<UserDto>(user);
    }
}