using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Repositories;
using MoneyShare.Domain.Users;
using MoneyShare.Infrastructure.Database;

namespace MoneyShare.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context)
        : base(context) { }

    // Just to showcase, don't really need this method
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await AppDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public AppDbContext AppDbContext
    {
        get { return Context as AppDbContext; }
    }
}
