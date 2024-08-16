using Microsoft.EntityFrameworkCore;
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
        private readonly AppDbContext _context;

        private Dictionary<string, object> Repositories { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Repositories = new Dictionary<string, dynamic>();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        // Get generic repository for an entity
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var typeName = typeof(TEntity).Name;

            lock (Repositories)
            {
                if (Repositories.TryGetValue(typeName, out object? value))
                {
                    return (IRepository<TEntity>)value;
                }

                var repository = new Repository<TEntity>(_context);

                Repositories.Add(typeName, repository);
                return repository;
            }
        }
    }
}
