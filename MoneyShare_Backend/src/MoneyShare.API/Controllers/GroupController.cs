using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoneyShare.API.Extensions;
using MoneyShare.API.Infrastructure;
using MoneyShare.Application.Groups.InviteUsers;
using MoneyShare.Domain.Bills;
using SharedKernel;

namespace MoneyShare.API.Controllers;

[ApiController]
[Route("/groups")]
public class GroupController(IMediator mediator) : ControllerBase
{
    [Route("{groupId}")]
    [HttpGet]
    public async Task<IEnumerable<Bill>> GetBillsInGroup(Guid groupId)
    {
        //return await _service.GetBillsInGroup(groupId);
        return [];
    }

    //[Route("{id}")]
    //[HttpGet]
    //public async Task<Group> GetGroupById(Guid id)
    //{
    //    return await _service.GetByIdAsync(id);
    //}

    //[Route("add_users")]
    //[HttpPost]
    //public async Task<IResult> AddUsers(InviteUsersToGroupCommand command)
    //{
    //    if (command.GroupId.Equals(0) || command.UserIds.IsNullOrEmpty())
    //    {
    //        return Results.BadRequest(command);
    //    }
    //    Result result = await _mediator.Send(command);

    //    return result.Match(Results.NoContent, CustomResults.Problem);
    //}
}
