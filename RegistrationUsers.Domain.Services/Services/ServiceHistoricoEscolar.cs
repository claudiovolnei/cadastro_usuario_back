using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Domain.Services.Services
{
    public class ServiceHistoricoEscolar : ServiceBase<HistoricoEscolar>, IServiceHistoricoEscolar
    {
        private readonly IRepositoryHistoricoEscolar _repositoryHistoricoEscolar;
        public ServiceHistoricoEscolar(IRepositoryHistoricoEscolar repositoryHistoricoEscolar) : base(repositoryHistoricoEscolar)
        {
            _repositoryHistoricoEscolar = repositoryHistoricoEscolar;   
        }
    }
}
