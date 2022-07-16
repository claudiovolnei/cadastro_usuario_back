using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Domain.Services.Services
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        public ServiceUsuario(IRepositoryUsuario repositoryUsuario) : base(repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario; 
        }

    }
}
