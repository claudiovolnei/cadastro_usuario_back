using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Domain.Core.Interfaces.Services
{
    public interface IServiceUser : IServiceBase<User>
    {
        Task<User> GetUserAsync(int id);
    }
}
