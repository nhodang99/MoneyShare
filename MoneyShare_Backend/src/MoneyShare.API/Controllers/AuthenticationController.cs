#region

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyShare.API.Extensions;
using MoneyShare.API.Infrastructure;
using MoneyShare.Application.Auth.Login;
using MoneyShare.Application.Auth.Refresh;
using MoneyShare.Application.Auth.Register;

#endregion

namespace MoneyShare.API.Controllers;

[ApiController]
[Route("/users")]
public class AuthenticationController(IMediator mediator) : Controller
{
    [HttpPost]
    [Route("login")]
    public async Task<IResult> Login([FromBody] LoginUserCommand command)
    {
        var result = await mediator.Send(command);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [HttpPost]
    [Route("register")]
    public async Task<IResult> Register([FromBody] RegisterUserCommand command)
    {
        IdentityResult result = await mediator.Send(command);

        if (!result.Succeeded)
        {
            return Results.ValidationProblem(result.Errors
                .GroupBy(e => e.Code)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.Description).ToArray()
                ));
        }

        return Results.Created();
    }

    [HttpPost]
    [Route("refresh")]
    public async Task<IResult> Refresh([FromBody] RefreshTokenCommand command)
    {
        if (string.IsNullOrEmpty(command.RefreshToken))
        {
            return Results.BadRequest(new { message = "Refresh token is required" });
        }

        var result = await mediator.Send(command);

        return result.Match(Results.Ok, CustomResults.Problem);
    }
}