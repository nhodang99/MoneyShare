using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Repositories;
using MoneyShare.Infrastructure.Database;

namespace MoneyShare.Infrastructure.Repositories;

public class GroupRepository(DbContext context) : Repository<Group>(context), IGroupRepository
{
    public AppDbContext AppDbContext => (Context as AppDbContext)!;
}
