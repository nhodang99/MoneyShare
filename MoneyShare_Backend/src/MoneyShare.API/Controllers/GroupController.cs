using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyShare.API.Extensions;
using MoneyShare.API.Infrastructure;
using MoneyShare.Application.Bills.GetById;
using MoneyShare.Application.Bills;
using MoneyShare.Application.Groups;
using MoneyShare.Application.Groups.Create;
using MoneyShare.Application.Groups.Delete;
using MoneyShare.Application.Groups.Edit;
using MoneyShare.Application.Groups.GetAll;
using MoneyShare.Application.Groups.GetById;
using MoneyShare.Application.Groups.InviteUsers;
using MoneyShare.Application.Groups.RemoveUsers;
using SharedKernel;
using MoneyShare.Application.Bills.GetBillsInGroup;

namespace MoneyShare.API.Controllers;

[ApiController]
[Route("/groups")]
public class GroupController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetAllGroups()
    {
        var query = new GetAllGroupsQuery();
        Result<IEnumerable<GroupDTO>> result = await mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Route("{groupId}")]
    [HttpGet]
    public async Task<IResult> GetGroupById(Guid groupId)
    {
        var query = new GetGroupByIdQuery(groupId);
        Result<GroupDTO> result = await mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    // POST bills_in_group?groupId={groupId}&pageSize={pageSize}&pageIndex={pageIndex}
    [Route("bills_in_group")]
    [HttpGet]
    public async Task<IResult> GetBillsInGroup(Guid groupId, int pageIndex, int pageSize)
    {
        var query = new GetBillsInGroupQuery(groupId, pageIndex, pageSize);
        var result = await mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Route("delete/{groupId}")]
    [HttpPost]
    public async Task<IResult> DeleteGroupById(Guid groupId)
    {
        var command = new DeleteGroupCommand(groupId);
        Result result = await mediator.Send(command);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }

    [Route("edit")]
    [HttpPost]
    public async Task<IResult> EditGroupById([FromBody] EditGroupCommand command)
    {
        Result result = await mediator.Send(command);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }

    [Route("create")]
    [HttpPost]
    public async Task<IResult> AddGroup([FromBody] CreateGroupCommand command)
    {
        var result = await mediator.Send(command);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Route("invite_users")]
    [HttpPost]
    public async Task<IResult> InviteUsersToGroup([FromBody] InviteUsersToGroupCommand command)
    {
        var result = await mediator.Send(command);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }

    [Route("remove_users")]
    [HttpPost]
    public async Task<IResult> InviteUsersToGroup([FromBody] RemoveUsersFromGroupCommand command)
    {
        var result = await mediator.Send(command);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }
}
