using MoneyShare.API.Base;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Interfaces;

namespace MoneyShare.API.Services
{
    public class GroupsService : BaseService<Group>
    {
        public GroupsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // public void AddUser(int userId)
        // {
            // var user = _unitOfWork.Users.Get(userId);
            // if (user != null)
            // {
                
            // }
        // }
    }
}
