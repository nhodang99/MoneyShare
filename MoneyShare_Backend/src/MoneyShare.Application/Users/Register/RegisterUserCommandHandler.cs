﻿using MoneyShare.Application.Contracts.Authentication;
using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Domain.Users;
using SharedKernel;

namespace MoneyShare.Application.Users.Register;

internal sealed class RegisterUserCommandHandler(
    IUnitOfWork unitOfWork,
    IPasswordHasher passwordHasher,
    IAuthenticationService authenticationService)
: ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        if (await unitOfWork.Users.AnyAsync(u => u.Email == command.Email, cancellationToken))
        {
            return Result.Failure<Guid>(UserErrors.EmailNotUnique);
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = command.Email,
            UserName = command.UserName,
            PasswordHash = passwordHasher.Hash(command.Password)
        };

        return await authenticationService.Register(user, cancellationToken);
    }
}
