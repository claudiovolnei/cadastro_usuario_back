using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Core.Interfaces.Services;

namespace RegistrationUsers.Domain.Services.Services
{
    public abstract class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class 
    {
        private readonly IRepositoryBase<TEntity> _repository;
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public virtual void Add(TEntity obj)
        {
            _repository.Add(obj);
        }
        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
        public virtual void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
        public virtual void Remove(TEntity obj)
        {
            _repository.Delete(obj);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
