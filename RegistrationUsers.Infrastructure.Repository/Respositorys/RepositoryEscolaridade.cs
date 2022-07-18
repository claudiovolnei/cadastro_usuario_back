using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.Data;

namespace RegistrationUsers.Infrastructure.Repository.Respositorys
{
    public class RepositoryEscolaridade : RepositoryBase<Escolaridade>, IRepositoryEscolaridade
    {
        private readonly RegistrationUserDBContext _context;
        public RepositoryEscolaridade(RegistrationUserDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
