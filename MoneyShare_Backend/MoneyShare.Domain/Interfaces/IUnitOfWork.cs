using MoneyShare.Domain.Base;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Users;

namespace MoneyShare.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        int Commit();
    }
}
