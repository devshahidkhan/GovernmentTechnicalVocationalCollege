using GovernmentTechnicalVocationalCollege.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace GovernmentTechnicalVocationalCollege.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<TrainingProgram> Programs { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<AcademicSession> AcademicSessions { get; set; }
    }
}
