using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Repositories;
using MoneyShare.Domain.Users;
using MoneyShare.Infrastructure.Database;

namespace MoneyShare.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : Repository<User>(context), IUserRepository
{
    public AppDbContext AppDbContext => (Context as AppDbContext)!;
}
