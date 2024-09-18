using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Repositories;
using MoneyShare.Infrastructure.Database;

namespace MoneyShare.Infrastructure.Repositories;

public class BillRepository(AppDbContext context) : Repository<Bill>(context), IBillRepository
{
    public AppDbContext AppDbContext => (Context as AppDbContext)!;

    public async Task<IEnumerable<Bill>> GetBillsInGroupAsync(Guid groupId, int pageIndex, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        return await AppDbContext.Bills
            .Where(b => b.GroupId == groupId)
            .OrderByDescending(b => b.UpdatedDate)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}
