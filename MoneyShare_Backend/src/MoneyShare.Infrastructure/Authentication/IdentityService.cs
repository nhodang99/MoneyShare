#region

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoneyShare.Application.Auth.Login;
using MoneyShare.Application.Auth.Register;
using MoneyShare.Application.Interfaces.Authentication;
using MoneyShare.Application.Models;

#endregion

namespace MoneyShare.Infrastructure.Authentication;

public class IdentityService(
    UserManager<ApplicationUser> userManager,
    IMapper mapper,
    IHttpContextAccessor httpContextAccessor) : IIdentityService
{
    public async Task<IdentityResult> RegisterAsync(RegisterUserCommand command)
    {
        List<IdentityError> errors = [];

        if (await userManager.FindByNameAsync(command.UserName) != null)
        {
            errors.Add(new IdentityError
            {
                Code = "Auth.InvalidUserName",
                Description = "User name is already taken"
            });
        }

        if (await userManager.FindByEmailAsync(command.Email) != null)
        {
            errors.Add(new IdentityError
            {
                Code = "Auth.InvalidEmail",
                Description = "Email is already taken"
            });
        }

        if (command.Password != command.ConfirmPassword)
        {
            errors.Add(new IdentityError
            {
                Code = "Auth.InvalidPassword",
                Description = "Password and Confirm password must be the same"
            });
        }

        if (errors.Count != 0)
        {
            return IdentityResult.Failed([.. errors]);
        }

        var appUser = mapper.Map<ApplicationUser>(command);

        var res = await userManager.CreateAsync(appUser, command.Password);
        if (res.Succeeded)
        {
            await userManager.AddToRolesAsync(appUser, ["User"]);
        }

        return res;
    }

    public async Task<ApplicationUser?> LoginAsync(LoginUserCommand command)
    {
        var user = await userManager.FindByEmailAsync(command.Email);

        if (user is not null
            && await userManager.CheckPasswordAsync(user, command.Password))
        {
            return user;
        }

        return null;
    }

    public async Task<ApplicationUser?> GetUserByRefreshTokenAsync(string refreshToken)
    {
        return await userManager.Users
            .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
    }

    public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
    {
        return await userManager.UpdateAsync(user);
    }
}