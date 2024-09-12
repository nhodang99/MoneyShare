using MoneyShare.Application.Contracts.Authentication;
using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Users;
using SharedKernel;

namespace MoneyShare.Application.Users.Login;

internal sealed class LoginUserCommandHandler(
    IUnitOfWork unitOfWork,
    IPasswordHasher passwordHasher,
    ITokenProvider tokenProvider) : ICommandHandler<LoginUserCommand, string>
{

    public async Task<Result<string>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        User? user = await unitOfWork.Users.SingleOrDefaultAsync(u => u.Email == command.Email, cancellationToken);

        if (user is null)
        {
            return Result.Failure<string>(UserErrors.NotFoundByEmail);
        }

        bool verified = passwordHasher.Verify(command.Password, user.PasswordHash);
        if (!verified)
        {
            return Result.Failure<string>(UserErrors.IncorrectPassword);
        }

        string token = tokenProvider.Create(user);

        return token;
    }
}
