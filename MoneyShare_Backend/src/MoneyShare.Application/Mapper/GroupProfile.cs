using AutoMapper;
using MoneyShare.Application.Groups;
using MoneyShare.Domain.Groups;

namespace MoneyShare.Application.Mapper;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<Group, GroupDTO>();
    }
}
