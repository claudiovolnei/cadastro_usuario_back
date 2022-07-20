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
        public async virtual Task<TEntity> Add(TEntity obj)
        {
            await _repository.Add(obj);
            return obj;
        }
        public async virtual Task<TEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async virtual Task<TEntity> Update(TEntity obj)
        {
            await _repository.Update(obj);
            return obj;

        }
        public async virtual Task Remove(TEntity obj)
        {
            await _repository.Delete(obj);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
