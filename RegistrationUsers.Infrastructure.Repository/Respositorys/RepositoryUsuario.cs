using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.Data;

namespace RegistrationUsers.Infrastructure.Repository.Respositorys
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly RegistrationUserDBContext _context;
        public RepositoryUsuario(RegistrationUserDBContext context) : base(context)
        {
            _context = context; 
        }
    }
}
