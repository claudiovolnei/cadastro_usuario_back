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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.EnableSensitiveDataLogging();
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .HasColumnName("sobrenome")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("data_nascimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.EscolaridadeId).HasColumnName("escolaridade_id");
                entity.Property(e => e.HistoricoEscolarId).HasColumnName("historico_escolar_id");


            });
            modelBuilder.Entity<Escolaridade>(entity =>
            {
                entity.ToTable("Escolaridade");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricao)
                  .HasColumnName("descricao")
                  .HasMaxLength(30)
                  .IsUnicode(false);

            });
            modelBuilder.Entity<Escolaridade>()
                .HasData(
                    new Escolaridade
                    {
                        Id = 1,
                        Descricao = "Ensino Infantil"
                    },
                    new Escolaridade
                    {
                        Id = 2,
                        Descricao = "Ensino Fundamental"
                    },
                    new Escolaridade
                    {
                        Id = 3,
                        Descricao = "Ensino Médio"
                    },
                    new Escolaridade
                    {
                        Id = 4,
                        Descricao = "Ensino Superior"
                    }
                );
            modelBuilder.Entity<HistoricoEscolar>(entity =>
            {
                entity.ToTable("HistoricoEscolar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                  .HasColumnName("nome")
                  .HasMaxLength(30)
                  .IsUnicode(false);

                entity.Property(e => e.Formato)
                  .HasColumnName("formato")
                  .HasMaxLength(30)
                  .IsUnicode(false);
                
                entity.Property(e => e.Caminho)
                  .HasColumnName("caminho")
                  .HasMaxLength(int.MaxValue)
                  .IsUnicode(false);
            });
            
        }
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
