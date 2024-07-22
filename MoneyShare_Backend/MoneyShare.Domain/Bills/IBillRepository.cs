using MoneyShare.Domain.Interfaces;

namespace MoneyShare.Domain.Bills
{
    public interface IBillRepository : IRepository<Bill>
    {
        IEnumerable<Bill> GetAllBillsInGroup(int groupId);
        void DeleteAllBillsInGroup(int groupId);

        IEnumerable<Bill> GetAllBillsByUser(int userId);
    }
}
