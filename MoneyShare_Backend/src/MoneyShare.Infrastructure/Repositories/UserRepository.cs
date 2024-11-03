#region

using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Repositories;
using MoneyShare.Domain.Users;
using MoneyShare.Infrastructure.Database;

#endregion

namespace MoneyShare.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : Repository<User>(context), IUserRepository
{
    public AppDbContext AppDbContext => (Context as AppDbContext)!;

    public async Task<decimal> GetTotalLoan(Guid userId)
    {
        return await AppDbContext.Users
            .Where(u => u.Id == userId)
            .SelectMany(u => u.Bills)
            .Where(b => b.Status == BillStatus.Pending)
            .SumAsync(b => b.Price);
    }
}