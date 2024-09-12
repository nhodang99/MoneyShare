using AutoMapper;
using MoneyShare.Application.Bills;
using MoneyShare.Domain.Bills;

namespace MoneyShare.Application.Mapper;

public class BillProfile : Profile
{
    public BillProfile()
    {
        CreateMap<Bill, BillDTO>();
    }
}
