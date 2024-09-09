using MoneyShare.Application.Contracts.Interfaces;
using MoneyShare.Domain.Users;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Bills;
using MoneyShare.Application.Contracts.Requests;
using SharedKernel;
using MoneyShare.Domain;

namespace MoneyShare.Application.Services;

public class GroupService : IGroupService
{
    private readonly IUnitOfWork _unitOfWork;

    public GroupService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    public async Task<Result> AddUsers(AddUsersToGroupReq req)
    {
        var group = await _unitOfWork.Groups.GetAsync(req.GroupId);
        if (group == null)
        {
            return Result.Failure(GroupErrors.NotFound(req.GroupId));
        }

        foreach (var userId in req.UserIds)
        {
            if (await _unitOfWork.Users.GetAsync(userId) == null)
            {
                return Result.Failure(UserErrors.NotFound(userId));
            }

            // Todo: finish this func
        }
        await _unitOfWork.CommitAsync();
        return Result.Success();
    }

    public IEnumerable<Bill> GetAllBillsInGroup(Guid groupId)
    {
        return [];
    }

    public async Task<bool> RemoveUsers(RemoveUsersFromGroupReq reqBody)
    {
        var group = await _unitOfWork.Groups.GetAsync(reqBody.GroupId);
        if (group == null)
        {
            return false;
        }

        foreach (var userId in reqBody.UserIds)
        {
            //var item = group.Groups_Users.FirstOrDefault(x => x.GroupId == userId);
            //if (item == null)
            //{
            //    return false;
            //}
            //group.Groups_Users.Remove(item);
        }
        await _unitOfWork.CommitAsync();
        return true;
    }
}
