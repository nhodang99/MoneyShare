using AutoMapper;
using MoneyShare.Application.Groups;
using MoneyShare.Application.Groups.Create;
using MoneyShare.Application.Groups.Edit;
using MoneyShare.Domain.Groups;

namespace MoneyShare.Application.Mapper;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<Group, GroupDTO>();
        CreateMap<EditGroupCommand, Group>();
        CreateMap<CreateGroupCommand, Group>();
    }
}
