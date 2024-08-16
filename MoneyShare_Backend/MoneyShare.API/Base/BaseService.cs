using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoneyShare.API.Interfaces;
using MoneyShare.Domain.Interfaces;

namespace MoneyShare.API.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<TEntity> _repository;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<TEntity>();
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

        public void Update(int id, TEntity updatedEntity)
        {
            var entity = _repository.Get(id);
            if (entity != null)
            {
                _repository.GetEntry(entity).State = EntityState.Detached;
                _repository.Update(updatedEntity);
                _unitOfWork.Commit();
            }
        }
    }
}
