using MoneyShare.API.Base;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Interfaces;

namespace MoneyShare.API.Services
{
    public class BillsService : BaseService<Bill>
    {
        public BillsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Bill> GetBillsInGroup(int groupId)
        {
            return _unitOfWork.Bills.GetAllBillsInGroup(groupId);
        }

        public IEnumerable<Bill> GetBillsByUser(int userId)
        {
            return _unitOfWork.Bills.GetAllBillsByUser(userId);
        }

        public void DeleteBillsInGroup(int groupId)
        {
            _unitOfWork.Bills.DeleteAllBillsInGroup(groupId);
            _unitOfWork.Commit();
        }
    }
}
