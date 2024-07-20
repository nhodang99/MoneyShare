using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Bills;

namespace MoneyShare.Infrastructure.Repositories
{
    public class BillRepository : Repository<Bill>, IBillRepository
    {
        public BillRepository(AppDbContext context) : base(context)
        {
        }

        //public Bill GetBillsWithGroupAndUser(int id)
        //{

        //}

        public void DeleteAllBillsInGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bill> getAllBillsByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bill> GetAllBillsInGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public AppDbContext AppDbContext => Context as AppDbContext;
    }
}
