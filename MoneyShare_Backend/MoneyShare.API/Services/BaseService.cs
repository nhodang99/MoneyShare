using MoneyShare.API.Interfaces;
using MoneyShare.Domain.Base;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Interfaces;

namespace MoneyShare.API.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<TEntity>();

        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void DeleteById(int id)
        {
            TEntity entity = _repository.Get(id);
            if (entity != null)
            {
                _repository.Remove(entity);
                _unitOfWork.Commit();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Update(TEntity newEntity)
        {
            TEntity entity = _repository.Get(((IEntityBase<int>)newEntity).Id); // @TODO
            if (entity != null)
            {
                _repository.Remove(entity);
                _unitOfWork.Commit();
            }
        }
    }
}
