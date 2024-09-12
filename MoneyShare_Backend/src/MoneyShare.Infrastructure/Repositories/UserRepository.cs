using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Repositories;
using MoneyShare.Domain.Users;
using MoneyShare.Infrastructure.Database;

namespace MoneyShare.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context)
        : base(context) { }

    public AppDbContext AppDbContext => (Context as AppDbContext)!;
}
