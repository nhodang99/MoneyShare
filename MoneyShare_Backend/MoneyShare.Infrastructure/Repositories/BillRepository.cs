using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoneyShare.Domain.Bills;

namespace MoneyShare.Infrastructure.Repositories
{
    public class BillRepository : Repository<Bill>, IBillRepository
    {
        public BillRepository(AppDbContext context) : base(context)
        {
        }

        public void DeleteAllBillsInGroup(int groupId)
        {
            var bills = Find(b=> b.GroupId == groupId);
            if (bills != null)
            {
                RemoveRange(bills);
            }
        }

        public IEnumerable<Bill> GetAllBillsByUser(int userId)
        {
            return Find(b => b.PayerId == userId).ToList();
        }

        public IEnumerable<Bill> GetAllBillsInGroup(int groupId)
        {
            return Find(b => b.GroupId == groupId).ToList();
        }

        public AppDbContext AppDbContext => Context as AppDbContext;
    }
}
