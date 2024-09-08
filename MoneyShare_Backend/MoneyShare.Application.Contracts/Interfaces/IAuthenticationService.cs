using MoneyShare.Application.Contracts.Requests;
using SharedKernel;

namespace MoneyShare.Application.Contracts.Interfaces;

public interface IAuthenticationService
{
    Task<Result<string>> Login(LoginReq loginReq);

    Task<Result<Guid>> Register(RegisterReq registerReq);
}
