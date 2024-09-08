using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoneyShare.API.Extensions;
using MoneyShare.API.Infrastructure;
using MoneyShare.Application.Contracts.Interfaces;
using MoneyShare.Application.Contracts.Requests;
using MoneyShare.Domain.Bills;
using SharedKernel;

namespace MoneyShare.API.Controllers;

[ApiController]
[Route("/groups")]
public class GroupController : ControllerBase
{
    private readonly IGroupService _service;

    public GroupController(IGroupService service)
    {
        _service = service;
    }

    [Route("group/{groupId}")]
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

    [Route("add_users")]
    [HttpPost]
    public async Task<IResult> AddUsers(AddUsersToGroupReq addUsersToGroupReq)
    {
        if (addUsersToGroupReq.GroupId.Equals(0) || addUsersToGroupReq.UserIds.IsNullOrEmpty())
        {
            return Results.BadRequest(addUsersToGroupReq);
        }
        Result result = await _service.AddUsers(addUsersToGroupReq);
        return result.Match(Results.NoContent, CustomResults.Problem);
    }
}
