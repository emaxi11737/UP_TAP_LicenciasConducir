using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using UP_TAP_LicenciasConducir.Core.Entities;

namespace UP_TAP_LicenciasConducir.Infrastructure.Data
{
    public class LicenciasConducirDataContext : DbContext
    {
        public LicenciasConducirDataContext()
        {
        }

        public LicenciasConducirDataContext(DbContextOptions<LicenciasConducirDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<MedicalRevision> MedicalRevisions { get; set; }
        public virtual DbSet<MedicalShift> MedicalShifts { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Answer> Comments { get; set; }
        public virtual DbSet<Security> Securities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DataContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
