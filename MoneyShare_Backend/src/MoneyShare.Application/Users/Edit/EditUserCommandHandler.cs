#region

using AutoMapper;
using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Domain.Users;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Users.Edit;

internal sealed class EditUserCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IUserDomainService userService) : ICommandHandler<EditUserCommand>
{
    public async Task<Result> Handle(EditUserCommand command, CancellationToken cancellationToken)
    {
        User? user = await unitOfWork.Users.SingleOrDefaultAsync(u => u.Id == command.Id, cancellationToken);
        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound(command.Id));
        }

        user = mapper.Map<User>(command);

        return await userService.EditUserAsync(user, cancellationToken);
    }
}