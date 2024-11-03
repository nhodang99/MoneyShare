#region

using MoneyShare.Domain.Users;

#endregion

namespace MoneyShare.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<decimal> GetTotalLoan(Guid userId);
}