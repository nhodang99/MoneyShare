#region

using AutoMapper;
using MoneyShare.Application.Auth.Register;
using MoneyShare.Application.Models;

#endregion

namespace MoneyShare.Infrastructure.Authentication;

public class IdentityProfile : Profile
{
    public IdentityProfile()
    {
        CreateMap<RegisterUserCommand, ApplicationUser>();
    }
}