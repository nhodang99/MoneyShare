using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyShare.API.Extensions;
using MoneyShare.API.Infrastructure;
using MoneyShare.Application.Users;
using MoneyShare.Application.Users.Delete;
using MoneyShare.Application.Users.Edit;
using MoneyShare.Application.Users.GetAll;
using MoneyShare.Application.Users.GetByEmail;
using MoneyShare.Application.Users.GetById;
using SharedKernel;

namespace MoneyShare.API.Controllers;

[ApiController]
[Route("/users")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetAllUsers()
    {
        var query = new GetAllUsersQuery();
        var result = await mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Route("{userId}")]
    [HttpGet]
    public async Task<IResult> GetUserById(Guid userId)
    {
        var query = new GetUserByIdQuery(userId);
        Result<UserDTO> result = await mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Route("email={userEmail}")]
    [HttpGet]
    public async Task<IResult> GetUserByEmail(string userEmail)
    {
        var query = new GetUserByEmailQuery(userEmail);
        Result<UserDTO> result = await mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Route("delete/{userId}")]
    [HttpPost]
    public async Task<IResult> DeleteUserById(Guid userId)
    {
        var command = new DeleteUserCommand(userId);
        Result result = await mediator.Send(command);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }

    [Route("edit")]
    [HttpPost]
    public async Task<IResult> EditUserById([FromBody]EditUserCommand command)
    {
        Result result = await mediator.Send(command);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }
}
