using AutoMapper;
using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Users;
using SharedKernel;

namespace MoneyShare.Application.Users.GetByEmail;

internal sealed class GetUserByEmailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetUserByEmailQuery, UserDTO>
{
    public async Task<Result<UserDTO>> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
    {
        User? user = await unitOfWork.Users.SingleOrDefaultAsync(u => u.Email == query.Email, cancellationToken);
        if (user is null)
        {
            return Result.Failure<UserDTO>(UserErrors.NotFoundByEmail);
        }

        return mapper.Map<UserDTO>(user);
    }
}
