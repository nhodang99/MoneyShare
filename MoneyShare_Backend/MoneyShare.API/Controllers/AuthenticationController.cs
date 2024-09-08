using Microsoft.AspNetCore.Mvc;
using MoneyShare.API.Extensions;
using MoneyShare.API.Infrastructure;
using MoneyShare.Application.Contracts.Interfaces;
using MoneyShare.Application.Contracts.Requests;
using SharedKernel;

namespace MoneyShare.API.Controllers;

[ApiController]
[Route("/users")]
public class AuthenticationController : Controller
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IResult> Login(LoginReq loginReq)
    {
        Result<string> result = await _authenticationService.Login(loginReq);
        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [HttpPost]
    [Route("register")]
    public async Task<IResult> Register(RegisterReq registerReq)
    {
        Result<Guid> result = await _authenticationService.Register(registerReq);
        return result.Match(Results.Ok, CustomResults.Problem);
    }
}
