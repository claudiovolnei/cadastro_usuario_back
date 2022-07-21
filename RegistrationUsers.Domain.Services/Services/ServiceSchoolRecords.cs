using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Core.Interfaces.Services;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Domain.Services.Services
{
    public class ServiceSchoolRecords : ServiceBase<SchoolRecords>, IServiceSchoolRecords
    {
        private readonly IRepositorySchoolRecords _repositorySchoolRecords;
        public ServiceSchoolRecords(IRepositorySchoolRecords repositorySchoolRecords) : base(repositorySchoolRecords)
        {
            _repositorySchoolRecords = repositorySchoolRecords;   
        }
    }
}
