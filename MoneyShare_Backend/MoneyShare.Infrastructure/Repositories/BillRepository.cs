using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Repositories;
using MoneyShare.Infrastructure.Database;

namespace MoneyShare.Infrastructure.Repositories;

public class BillRepository : Repository<Bill>, IBillRepository
{
    public BillRepository(AppDbContext context)
        : base(context) { }

    public IEnumerable<Bill> GetBillsWithGroup(int pageIndex, int pageSize = 10)
    {
        return AppDbContext.Bills
            .Include(b => b.Group)
            .OrderBy(b => b.UpdatedDate)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public AppDbContext AppDbContext
    {
        get { return Context as AppDbContext; }
    }
}
