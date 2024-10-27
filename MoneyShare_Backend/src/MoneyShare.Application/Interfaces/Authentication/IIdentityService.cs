#region

using Microsoft.AspNetCore.Identity;
using MoneyShare.Application.Auth.Login;
using MoneyShare.Application.Auth.Register;
using MoneyShare.Application.Models;

#endregion

namespace MoneyShare.Application.Interfaces.Authentication;

public interface IIdentityService
{
    Task<IdentityResult> RegisterAsync(RegisterUserCommand command);
    Task<ApplicationUser?> LoginAsync(LoginUserCommand command);
    Task<ApplicationUser?> GetUserByRefreshTokenAsync(string refreshToken);
    Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
}