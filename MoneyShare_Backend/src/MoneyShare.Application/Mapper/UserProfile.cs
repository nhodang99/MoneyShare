using AutoMapper;
using MoneyShare.Application.Users;
using MoneyShare.Domain.Users;

namespace MoneyShare.Application.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>();
    }
}
