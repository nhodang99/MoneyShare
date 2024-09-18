using AutoMapper;
using MoneyShare.Application.Bills;
using MoneyShare.Application.Bills.Create;
using MoneyShare.Application.Bills.Edit;
using MoneyShare.Domain.Bills;

namespace MoneyShare.Application.Mapper;

public class BillProfile : Profile
{
    public BillProfile()
    {
        CreateMap<Bill, BillDTO>();
        CreateMap<CreateBillCommand, Bill>();
        CreateMap<EditBillCommand, Bill>();
    }
}
