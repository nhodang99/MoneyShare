using AutoMapper;
using MoneyShare.Application.Contracts.Authentication;
using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Domain.Users;
using SharedKernel;

namespace MoneyShare.Application.Users.Edit;

internal sealed class EditUserCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IPasswordHasher passwordHasher,
    IUserService userService) : ICommandHandler<EditUserCommand>
{
    public async Task<Result> Handle(EditUserCommand command, CancellationToken cancellationToken)
    {
        User? user = await unitOfWork.Users.SingleOrDefaultAsync(u => u.Id == command.Id, cancellationToken);
        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound(command.Id));
        }
        user = mapper.Map<User>(command);
        user.PasswordHash = passwordHasher.Hash(command.Password);

        return await userService.EditUser(user, cancellationToken);
    }
}
