using MoneyShare.Application.Contracts.Requests;
using MoneyShare.Domain.Bills;
using SharedKernel;

namespace MoneyShare.Application.Contracts.Interfaces;

public interface IGroupService
{
    IEnumerable<Bill> GetAllBillsInGroup(Guid groupId);
    Task<Result> AddUsers(AddUsersToGroupReq req);
}
