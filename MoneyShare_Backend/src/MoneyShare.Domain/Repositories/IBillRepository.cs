using MoneyShare.Domain.Bills;

namespace MoneyShare.Domain.Repositories;

public interface IBillRepository : IRepository<Bill>
{
    Task<IEnumerable<Bill>> GetBillsInGroupAsync(Guid groupId, int pageIndex, int pageSize = 10, CancellationToken cancellationToken = default);
}
