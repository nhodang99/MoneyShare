using MoneyShare.Application.Contracts.Interfaces;
using MoneyShare.Application.Contracts.DTOs;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain;

namespace MoneyShare.Application.Services;

public class BillService : IBillService
{
    private readonly IUnitOfWork _unitOfWork;

    public BillService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void AddBill(BillDTO bill)
    {
    }

    public Bill GetBillById(Guid id)
    {
        return null;
    }

    BillDTO IBillService.GetBillById(Guid id)
    {
        return null;
    }
}
