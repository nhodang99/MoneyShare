using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyShare.API.Extensions;
using MoneyShare.API.Infrastructure;
using MoneyShare.Application.Bills;
using MoneyShare.Application.Users;
using MoneyShare.Application.Users.GetAll;
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

    [Route("bills")]
    [HttpGet]
    public IEnumerable<BillDTO> GetBillsByUser(Guid userId)
    {
        return [];
    }
}
