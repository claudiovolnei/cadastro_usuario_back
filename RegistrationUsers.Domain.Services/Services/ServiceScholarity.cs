using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Domain.Services.Services
{
    public class ServiceScholarity : ServiceBase<Scholarity>, IServiceScholarity
    {
        private readonly IRepositoryScholarity _repositoryScholarity;
        public ServiceScholarity(IRepositoryScholarity repositoryScholarity) : base(repositoryScholarity)
        {
            _repositoryScholarity = repositoryScholarity;   
        }
    }
}
