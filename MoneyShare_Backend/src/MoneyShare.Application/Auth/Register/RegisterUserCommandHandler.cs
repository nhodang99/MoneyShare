#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MoneyShare.Application.Interfaces.Authentication;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Domain.Users;

#endregion

namespace MoneyShare.Application.Auth.Register;

internal sealed class RegisterUserCommandHandler(
    IIdentityService identityService,
    IUserDomainService userDomainService,
    IMapper mapper) : IRequestHandler<RegisterUserCommand, IdentityResult>
{
    public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var res = await identityService.RegisterAsync(request);
        if (res.Succeeded)
        {
            var user = mapper.Map<User>(request);
            await userDomainService.AddUserAsync(user, cancellationToken);
        }

        return res;
    }
}