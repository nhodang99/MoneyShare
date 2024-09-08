using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Users;
using MoneyShare.Infrastructure.Database;
using MoneyShare.Infrastructure.Repositories;

namespace MoneyShare.Infrastructure.Users;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context)
        : base(context) { }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await Context.Set<User>().AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
    }
}
