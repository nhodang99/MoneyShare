#region

using AutoMapper;
using MoneyShare.Application.Auth.Register;
using MoneyShare.Application.Users;
using MoneyShare.Application.Users.Edit;
using MoneyShare.Domain.Users;

#endregion

namespace MoneyShare.Application.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<RegisterUserCommand, User>();
        CreateMap<EditUserCommand, User>();
    }
}