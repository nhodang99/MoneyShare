using MoneyShare.Domain.Users;

namespace MoneyShare.Application.Contracts.Authentication;

public interface ITokenProvider
{
    string Create(User user);
}
