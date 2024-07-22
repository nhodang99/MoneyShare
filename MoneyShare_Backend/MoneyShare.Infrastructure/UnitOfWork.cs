using MoneyShare.Domain.Base;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Domain.Users;
using MoneyShare.Infrastructure.Repositories;

namespace MoneyShare.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Bills = new BillRepository(_context);
            Groups = new GroupRepository(_context);
        }

        private readonly AppDbContext _context;
        public IUserRepository Users { get; private set; }

        public IBillRepository Bills { get; private set; }

        public IGroupRepository Groups { get; private set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (typeof(TEntity) == typeof(User))
            {
                return (IRepository<TEntity>) Users;
            }
            else if (typeof(TEntity) == typeof(Group))
            {
                return (IRepository<TEntity>) Groups;
            }
            else if (typeof(TEntity) == typeof(Bill))
            {
                return (IRepository<TEntity>)Bills;
            }
            else
            {
                throw new ArgumentException("Unsupported entity type: " + typeof(TEntity).Name);
            }
        }
    }
}
