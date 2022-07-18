using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Domain.Services.Services
{
    public class ServiceEscolaridade : ServiceBase<Escolaridade>, IServiceEscolaridade
    {
        private readonly IRepositoryEscolaridade _repositoryEscolaridade;
        public ServiceEscolaridade(IRepositoryEscolaridade repositoryEscolaridade) : base(repositoryEscolaridade)
        {
            _repositoryEscolaridade = repositoryEscolaridade;   
        }
    }
}
