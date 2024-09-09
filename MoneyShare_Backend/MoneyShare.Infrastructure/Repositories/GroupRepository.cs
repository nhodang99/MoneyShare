using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Repositories;
using MoneyShare.Infrastructure.Database;

namespace MoneyShare.Infrastructure.Repositories;

public class GroupRepository : Repository<Group>, IGroupRepository
{
    public GroupRepository(DbContext context)
        : base(context)
    {
    }

    public AppDbContext AppDbContext
    {
        get { return Context as AppDbContext; }
    }
}
