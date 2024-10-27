#region

using AutoMapper;
using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Users;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Users.GetByEmail;

internal sealed class GetUserByEmailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<GetUserByEmailCommand, UserDto>
{
    public async Task<Result<UserDto>> Handle(GetUserByEmailCommand command, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.SingleOrDefaultAsync(u => u.Email == command.Email, cancellationToken);
        return user is null
            ? Result.Failure<UserDto>(UserErrors.NotFoundByEmail)
            : mapper.Map<UserDto>(user);
    }
}