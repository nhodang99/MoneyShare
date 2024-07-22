using MoneyShare.API.Base;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Domain.Users;

namespace MoneyShare.API.Services
{
    public class UsersService : BaseService<User>
    {
        public UsersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
