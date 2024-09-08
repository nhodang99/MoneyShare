using MoneyShare.Application.Contracts.Interfaces;
using MoneyShare.Domain.Users;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Repositories;
using MoneyShare.Application.Contracts.Requests;
using SharedKernel;

namespace MoneyShare.Application.Services;

public class GroupService : IGroupService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Group> _groupRepository;

    public GroupService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _groupRepository = _unitOfWork.Repository<Group>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    public async Task<Result> AddUsers(AddUsersToGroupReq req)
    {
        var group = await _groupRepository.GetAsync(req.GroupId);
        if (group == null)
        {
            return Result.Failure(GroupErrors.NotFound(req.GroupId));
        }

        foreach (var userId in req.UserIds)
        {
            if (await _unitOfWork.Repository<User>().GetAsync(userId) == null)
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
        var group = await _groupRepository.GetAsync(reqBody.GroupId);
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
