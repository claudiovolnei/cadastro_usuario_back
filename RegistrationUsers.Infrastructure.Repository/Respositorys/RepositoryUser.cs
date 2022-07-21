using Microsoft.EntityFrameworkCore;
using RegistrationUsers.Domain.Core.Interfaces.Repositorys;
using RegistrationUsers.Domain.Models;
using RegistrationUsers.Infrastructure.Data;

namespace RegistrationUsers.Infrastructure.Repository.Respositorys
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        private readonly RegistrationUserDBContext _context;
        public RepositoryUser(RegistrationUserDBContext context) : base(context)
        {
            _context = context; 
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _context.Users.Where(u => u.Id == id)
                        .Include(e => e.Scholarity)
                        .Include(h => h.SchoolRecords)
                        .FirstOrDefaultAsync();
            return user;
        }
    }
}
