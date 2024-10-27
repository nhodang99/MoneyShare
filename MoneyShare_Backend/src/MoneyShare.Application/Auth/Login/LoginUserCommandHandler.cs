#region

using MoneyShare.Application.Interfaces.Authentication;
using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain.Users;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Auth.Login;

internal sealed class LoginUserCommandHandler(
    IIdentityService identityService,
    IJwtProvider jwtProvider) : ICommandHandler<LoginUserCommand, LoginUserResponse>
{
    public async Task<Result<LoginUserResponse>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        var user = await identityService.LoginAsync(command);
        if (user is null)
        {
            return Result.Failure<LoginUserResponse>(UserErrors.NotFoundByEmail);
        }

        var (accessToken, refreshToken) = jwtProvider.Generate(user);

        var result = await identityService.UpdateUserAsync(user);
        if (!result.Succeeded)
        {
            return Result.Failure<LoginUserResponse>(
                new Error("Auth.Error", "Internal error", ErrorType.Problem));
        }

        return new LoginUserResponse(accessToken, refreshToken);
    }
}