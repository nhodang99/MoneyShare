using MoneyShare.Domain.Bills;

namespace MoneyShare.Domain.Repositories;

public interface IBillRepository
{
    IEnumerable<Bill> GetBillsWithGroup(int pageIndex, int pageSize = 10);
}
