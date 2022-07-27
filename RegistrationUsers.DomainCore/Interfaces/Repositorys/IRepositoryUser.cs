using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
