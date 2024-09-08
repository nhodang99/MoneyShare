using MoneyShare.Domain.Repositories;

namespace MoneyShare.Domain.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}
