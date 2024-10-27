#region

using MoneyShare.Application.Interfaces.Authentication;
using MoneyShare.Application.Interfaces.Messaging;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Auth.Refresh;

internal class RefreshTokenCommandHandler(
    IIdentityService identityService,
    IJwtProvider jwtProvider) : ICommandHandler<RefreshTokenCommand, RefreshTokenResponse>
{
    public async Task<Result<RefreshTokenResponse>> Handle(RefreshTokenCommand command,
        CancellationToken cancellationToken)
    {
        var user = await identityService.GetUserByRefreshTokenAsync(command.RefreshToken);
        if (user is null)
        {
            return Result.Failure<RefreshTokenResponse>(new Error("Auth.Error", "Refresh token invalid",
                ErrorType.Validation)); // temp error
        }

        // Validate refresh token
        if (user.RefreshToken != command.RefreshToken && !(user.RefreshTokenExpiryTime > DateTime.UtcNow))
        {
            return Result.Failure<RefreshTokenResponse>(new Error("Auth.Error", "Error",
                ErrorType.Validation)); // temp error
        }

        var (accessToken, refreshToken) = jwtProvider.Generate(user);
        var result = await identityService.UpdateUserAsync(user);
        if (!result.Succeeded)
        {
            return Result.Failure<RefreshTokenResponse>(new Error("Auth.Error", "Internal error",
                ErrorType.Problem));
        }

        return new RefreshTokenResponse(accessToken, refreshToken);
    }
}