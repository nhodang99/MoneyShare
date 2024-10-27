#region

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyShare.API.Extensions;
using MoneyShare.API.Infrastructure;
using MoneyShare.Application.Users.Delete;
using MoneyShare.Application.Users.Edit;
using MoneyShare.Application.Users.GetAll;
using MoneyShare.Application.Users.GetByEmail;
using MoneyShare.Application.Users.GetById;

#endregion

namespace MoneyShare.API.Controllers;

[ApiController]
[Route("/users")]
public class UserController(IMediator mediator) : ControllerBase
{
    //[Authorize(Roles = "Admin")]
    [Authorize]
    [HttpGet]
    public async Task<IResult> GetAllUsers()
    {
        var query = new GetAllUsersQuery();
        var result = await mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Authorize]
    [Route("{userId:guid}")]
    [HttpGet]
    public async Task<IResult> GetUserById(Guid userId)
    {
        var query = new GetUserByIdQuery(userId);
        var result = await mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Authorize]
    [Route("email")]
    [HttpGet]
    public async Task<IResult> GetUserByEmail([FromBody] GetUserByEmailCommand command)
    {
        if (string.IsNullOrEmpty(command.Email))
        {
            return Results.BadRequest(new { message = "Email is required" });
        }

        var result = await mediator.Send(command);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Authorize]
    [Route("delete/{userId:guid}")]
    [HttpPost]
    public async Task<IResult> DeleteUserById(Guid userId)
    {
        var command = new DeleteUserCommand(userId);
        var result = await mediator.Send(command);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }

    [Authorize]
    [Route("edit")]
    [HttpPost]
    public async Task<IResult> EditUserById([FromBody] EditUserCommand command)
    {
        var result = await mediator.Send(command);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }
}