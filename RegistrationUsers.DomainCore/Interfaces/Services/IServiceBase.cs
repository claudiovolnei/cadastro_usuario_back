namespace RegistrationUsers.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class 
    {
        Task<TEntity> Add(TEntity obj);

        Task<TEntity> Update(TEntity obj);

        Task Remove(TEntity obj);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);
        void Dispose();
    }
}
