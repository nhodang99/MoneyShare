using MoneyShare.Domain.Base;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Interfaces;

namespace MoneyShare.API.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);

        void Add(TEntity entity);

        void DeleteById(int id);

        void Update(int id, TEntity entity);
    }
}
