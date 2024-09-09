using MoneyShare.Application.Contracts.Authentication;
using MoneyShare.Application.Contracts.Interfaces;
using MoneyShare.Application.Contracts.Requests;
using MoneyShare.Domain;
using MoneyShare.Domain.Users;
using SharedKernel;

namespace MoneyShare.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenProvider _tokenProvider;

    public AuthenticationService(
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        ITokenProvider tokenProvider)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _tokenProvider = tokenProvider;
    }

    public async Task<Result<string>> Login(LoginReq loginReq)
    {
        User? user = await _unitOfWork.Users.GetByEmailAsync(loginReq.Email);
        if (user is null)
        {
            return Result.Failure<string>(UserErrors.NotFoundByEmail);
        }

        bool verified = _passwordHasher.Verify(loginReq.Password, user.PasswordHash);

        if (!verified)
        {
            return Result.Failure<string>(UserErrors.NotFoundByEmail);
        }

        string token = _tokenProvider.Create(user);

        return token;
    }

    public async Task<Result<Guid>> Register(RegisterReq registerReq)
    {
        var anyUser = await _unitOfWork.Users.GetByEmailAsync(registerReq.Email);
        if (anyUser is not null)
        {
            return Result.Failure<Guid>(UserErrors.EmailNotUnique);
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = registerReq.Email,
            UserName = registerReq.UserName,
            PasswordHash = _passwordHasher.Hash(registerReq.Password)
        };

        _unitOfWork.Users.Add(user);

        await _unitOfWork.CommitAsync();

        return user.Id;
    }
}
