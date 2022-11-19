using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UP_TAP_LicenciasConducir.Core.Entities;

namespace UP_TAP_LicenciasConducir.Infrastructure.Data
{
    public partial class LicenciasConducirDataContext : DbContext
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
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Answer> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
