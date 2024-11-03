#region

using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyShare.API.Extensions;
using MoneyShare.API.Infrastructure;
using MoneyShare.Application.Models;
using MoneyShare.Application.Users.Delete;
using MoneyShare.Application.Users.Edit;
using MoneyShare.Application.Users.GetAll;
using MoneyShare.Application.Users.GetByEmail;
using MoneyShare.Application.Users.GetById;
using MoneyShare.Application.Users.GetTotalLoan;

#endregion

namespace MoneyShare.API.Controllers;

[ApiController]
[Authorize]
[Route("/users")]
public class UserController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : ControllerBase
{
    [Authorize(Roles = UserRoles.Admin)]
    [HttpGet]
    public async Task<IResult> GetAllUsers()
    {
        var query = new GetAllUsersQuery();
        var result = await mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Route("{userId:guid}")]
    [HttpGet]
    public async Task<IResult> GetUserById(Guid userId)
    {
        var query = new GetUserByIdQuery(userId);
        var result = await mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Route("email")]
    [HttpPost]
    public async Task<IResult> GetUserByEmail([FromBody] GetUserByEmailCommand command)
    {
        if (string.IsNullOrEmpty(command.Email))
        {
            return Results.BadRequest(new
            {
                error = "User.EmailRequired",
                message = "Email is required"
            });
        }

        var result = await mediator.Send(command);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Route("delete/{userId:guid}")]
    [HttpDelete]
    public async Task<IResult> DeleteUserById(Guid userId)
    {
        if (httpContextAccessor.HttpContext is null)
        {
            return Results.Problem("HttpContext is null.", statusCode: 500);
        }

        var claimsPrincipal = httpContextAccessor.HttpContext.User;

        var appUserId = claimsPrincipal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        var appUserEmail = claimsPrincipal.FindFirst(JwtRegisteredClaimNames.Email)?.Value;
        if (string.IsNullOrEmpty(appUserId) || string.IsNullOrEmpty(appUserEmail))
        {
            return Results.Unauthorized();
        }

        if (!httpContextAccessor.HttpContext.User.IsInRole(UserRoles.Admin))
        {
            var getByEmailResult = await mediator
                .Send(new GetUserByEmailCommand(appUserEmail));
            if (!getByEmailResult!.IsSuccess)
            {
                return CustomResults.Problem(getByEmailResult);
            }

            if (getByEmailResult.Value.Id != userId)
            {
                return Results.Unauthorized();
            }
        }

        var command = new DeleteUserCommand(userId);
        var result = await mediator.Send(command);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }

    [Route("edit")]
    [HttpPost]
    public async Task<IResult> EditUserById([FromBody] EditUserCommand command)
    {
        var result = await mediator.Send(command);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }

    [Route("total-loan/{userId:guid}")]
    [HttpGet]
    public async Task<IResult> GetUserTotalLoan(Guid userId)
    {
        var query = new GetTotalLoanQuery(userId);
        var result = await mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);
    }
}