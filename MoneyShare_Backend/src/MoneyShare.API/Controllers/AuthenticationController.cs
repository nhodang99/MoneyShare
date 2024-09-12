using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyShare.API.Extensions;
using MoneyShare.API.Infrastructure;
using MoneyShare.Application.Users.Login;
using MoneyShare.Application.Users.Register;
using SharedKernel;

namespace MoneyShare.API.Controllers;

[ApiController]
[Route("/users")]
public class AuthenticationController(IMediator mediator) : Controller
{
    [HttpPost]
    [Route("login")]
    public async Task<IResult> Login(LoginUserCommand command)
    {
        Result<string> result = await mediator.Send(command);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [HttpPost]
    [Route("register")]
    public async Task<IResult> Register(RegisterUserCommand command)
    {
        Result<Guid> result = await mediator.Send(command);

        return result.Match(Results.Ok, CustomResults.Problem);
    }
}
