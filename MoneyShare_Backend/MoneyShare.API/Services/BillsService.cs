using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Interfaces;

namespace MoneyShare.API.Services
{
    public class BillsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BillsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Bill> GetAllBills()
        {
            return _unitOfWork.Bills.GetAll();
        }

        public Bill GetBillById(int id)
        {
            return _unitOfWork.Bills.Get(id);
        }

        public void AddBill(Bill bill)
        {
            _unitOfWork.Bills.Add(bill);
            _unitOfWork.Commit();
        }

        public void DeleteBillById(int id)
        {
            _unitOfWork.Bills.Remove(_unitOfWork.Bills.Get(id));
            _unitOfWork.Commit();
        }

        public void UpdateBill(Bill modifiedBill)
        {
            var bill = _unitOfWork.Bills.Get(modifiedBill.Id);
            if (bill != null)
            {
                _unitOfWork.Bills.Update(modifiedBill);
                _unitOfWork.Commit();
            }
        }

        public IEnumerable<Bill> GetBillsInGroup(int groupId)
        {
            return _unitOfWork.Bills.GetAllBillsInGroup(groupId);
        }

        public IEnumerable<Bill> GetBillsByUser(int userId)
        {
            return _unitOfWork.Bills.getAllBillsByUser(userId);
        }

        public void DeleteBillsInGroup(int groupId)
        {
            _unitOfWork.Bills.DeleteAllBillsInGroup(groupId);
            _unitOfWork.Commit();
        }
    }
}
