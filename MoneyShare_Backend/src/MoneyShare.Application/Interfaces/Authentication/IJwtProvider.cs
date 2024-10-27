#region

using MoneyShare.Application.Models;

#endregion

namespace MoneyShare.Application.Interfaces.Authentication;

public interface IJwtProvider
{
    (string, string) Generate(ApplicationUser user);
}