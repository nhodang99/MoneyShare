using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MoneyShare.Application.Auth.Register;

public sealed record RegisterUserCommand(string Email, string UserName, string Password, string ConfirmPassword)
    : IRequest<IdentityResult>; // we can but no need to use ICommand
