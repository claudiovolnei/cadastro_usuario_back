using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
        void Dispose();
    }
}
