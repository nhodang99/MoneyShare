using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Users;

namespace MoneyShare.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        //public User GetUserWithBills(int id)
        //{
        //    return AppDbContext.Users.Include(u => u.Bills).SingleOrDefault(u => u.Id == id);
        //}

        public AppDbContext AppDbContext => Context as AppDbContext;
    }
}
