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

        public DbSet<User> Users { get; set; }
        public DbSet<Scholarity> Scholaritys { get; set; }
        public DbSet<SchoolRecords> SchoolRecords { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.EnableSensitiveDataLogging();
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScholarityId).HasColumnName("scholarity_id");
                entity.Property(e => e.SchoolRecordsId).HasColumnName("school_records_id");


            });
            modelBuilder.Entity<Scholarity>(entity =>
            {
                entity.ToTable("Scholarity");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                  .HasColumnName("description")
                  .HasMaxLength(30)
                  .IsUnicode(false);

            });
            modelBuilder.Entity<Scholarity>()
                .HasData(
                    new Scholarity
                    {
                        Id = 1,
                        Description = "Ensino Infantil"
                    },
                    new Scholarity
                    {
                        Id = 2,
                        Description = "Ensino Fundamental"
                    },
                    new Scholarity
                    {
                        Id = 3,
                        Description = "Ensino Médio"
                    },
                    new Scholarity
                    {
                        Id = 4,
                        Description = "Ensino Superior"
                    }
                );
            modelBuilder.Entity<SchoolRecords>(entity =>
            {
                entity.ToTable("SchoolRecords");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .HasMaxLength(30)
                  .IsUnicode(false);

                entity.Property(e => e.Format)
                  .HasColumnName("format")
                  .HasMaxLength(30)
                  .IsUnicode(false);
                
                entity.Property(e => e.Path)
                  .HasColumnName("path")
                  .HasMaxLength(int.MaxValue)
                  .IsUnicode(false);
            });
            
        }
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegistrationDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("RegistrationDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("RegistrationDate").IsModified = false;
                }


            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
