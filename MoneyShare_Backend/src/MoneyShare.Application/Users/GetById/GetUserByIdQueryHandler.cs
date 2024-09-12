using AutoMapper;
using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Users;
using SharedKernel;

namespace MoneyShare.Application.Users.GetById;

internal sealed class GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetUserByIdQuery, UserDTO>
{
    public async Task<Result<UserDTO>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        User? user = await unitOfWork.Users.SingleOrDefaultAsync(u => u.Id == query.UserId, cancellationToken);
        if (user is null)
        {
            return Result.Failure<UserDTO>(UserErrors.NotFoundByEmail);
        }

        return mapper.Map<UserDTO>(user);
    }
}
