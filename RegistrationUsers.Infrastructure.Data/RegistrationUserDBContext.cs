using Microsoft.EntityFrameworkCore;
using RegistrationUsers.Domain.Models;

namespace RegistrationUsers.Infrastructure.Data
{
    public class RegistrationUserDBContext : DbContext
    {
        public RegistrationUserDBContext()
        {

        }

        public RegistrationUserDBContext(DbContextOptions<RegistrationUserDBContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Escolaridade> Escolaridades { get; set; }
        public DbSet<HistoricoEscolar> HistoricoEscolares { get; set; }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }


            }

            return base.SaveChanges();
        }
    }
}
