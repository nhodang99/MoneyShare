using MoneyShare.API.Base;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Domain.Users;
using MoneyShare.Infrastructure.Repositories;

namespace MoneyShare.API.Services
{
    public class UsersService : BaseService<User>
    {
        private readonly IUserRepository Users;
        public UsersService(IUnitOfWork unitOfWork, IUserRepository userRepository) : base(unitOfWork)
        {
            Users = userRepository;
        }
    }
}
