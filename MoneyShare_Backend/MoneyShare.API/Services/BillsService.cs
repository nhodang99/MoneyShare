using MoneyShare.API.Base;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Infrastructure.Repositories;

namespace MoneyShare.API.Services
{
    public class BillsService : BaseService<Bill>
    {
        private readonly IBillRepository Bills;

        public BillsService(IUnitOfWork unitOfWork, IBillRepository billRepository) : base(unitOfWork)
        {
            Bills = billRepository;
        }

        public IEnumerable<Bill> GetBillsInGroup(int groupId)
        {
            return Bills.GetAllBillsInGroup(groupId);
        }

        public IEnumerable<Bill> GetBillsByUser(int userId)
        {
            return Bills.GetAllBillsByUser(userId);
        }

        public void DeleteBillsInGroup(int groupId)
        {
            Bills.DeleteAllBillsInGroup(groupId);
            _unitOfWork.Commit();
        }
    }
}
