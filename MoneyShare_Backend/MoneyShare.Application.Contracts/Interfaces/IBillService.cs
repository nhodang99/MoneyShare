using MoneyShare.Application.Contracts.DTOs;

namespace MoneyShare.Application.Contracts.Interfaces;

public interface IBillService
{
    void AddBill(BillDTO bill);
    BillDTO GetBillById(Guid id);
}
