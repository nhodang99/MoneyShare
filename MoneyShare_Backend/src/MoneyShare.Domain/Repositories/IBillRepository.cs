using MoneyShare.Domain.Bills;

namespace MoneyShare.Domain.Repositories;

public interface IBillRepository : IRepository<Bill>
{
    IEnumerable<Bill> GetBillsWithGroup(int pageIndex, int pageSize = 10);
}
