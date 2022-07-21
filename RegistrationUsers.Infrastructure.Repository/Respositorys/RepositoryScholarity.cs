using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.Data;

namespace RegistrationUsers.Infrastructure.Repository.Respositorys
{
    public class RepositoryScholarity : RepositoryBase<Scholarity>, IRepositoryScholarity
    {
        private readonly RegistrationUserDBContext _context;
        public RepositoryScholarity(RegistrationUserDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
