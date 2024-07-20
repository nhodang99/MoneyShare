using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Groups;

namespace MoneyShare.Infrastructure.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(DbContext context) : base(context)
        {
        }

        public AppDbContext AppDbContext => Context as AppDbContext;
    }
}
