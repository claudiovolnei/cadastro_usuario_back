using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Domain.Services.Services
{
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {
        private readonly IRepositoryUser _repositoryUser;
        public ServiceUser(IRepositoryUser repositoryUser) : base(repositoryUser)
        {
            _repositoryUser = repositoryUser; 
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _repositoryUser.GetAllAsync();
            return users;
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _repositoryUser.GetUserAsync(id);
            return user;

        }
    }
}
