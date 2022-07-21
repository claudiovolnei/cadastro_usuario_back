using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.Data;

namespace RegistrationUsers.Infrastructure.Repository.Respositorys
{
    public class RepositorySchoolRecords : RepositoryBase<SchoolRecords>, IRepositorySchoolRecords
    {
        private readonly RegistrationUserDBContext _context;
        public RepositorySchoolRecords(RegistrationUserDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
