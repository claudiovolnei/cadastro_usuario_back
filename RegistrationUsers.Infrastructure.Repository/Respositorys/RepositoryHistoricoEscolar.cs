using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.Data;

namespace RegistrationUsers.Infrastructure.Repository.Respositorys
{
    public class RepositoryHistoricoEscolar : RepositoryBase<HistoricoEscolar>, IRepositoryHistoricoEscolar
    {
        private readonly RegistrationUserDBContext _context;
        public RepositoryHistoricoEscolar(RegistrationUserDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
