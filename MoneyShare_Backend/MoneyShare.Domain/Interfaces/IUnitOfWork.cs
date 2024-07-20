using MoneyShare.Domain.Base;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Users;

namespace MoneyShare.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IBillRepository Bills { get; }
        IGroupRepository Groups { get; }
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        int Commit();
    }
}
