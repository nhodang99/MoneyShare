using MoneyShare.Domain.Interfaces;

namespace MoneyShare.Domain.Bills
{
    public interface IBillRepository : IRepository<Bill>
    {
        // Bill GetBillsWithGroupAndUser(int id);
        IEnumerable<Bill> GetAllBillsInGroup(int groupId);
        void DeleteAllBillsInGroup(int groupId);

        IEnumerable<Bill> getAllBillsByUser(int userId);
    }
}
