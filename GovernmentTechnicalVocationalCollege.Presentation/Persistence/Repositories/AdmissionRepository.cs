using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AdmissionRepository.Interface;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace GovernmentTechnicalVocationalCollege.Presentation.Persistence.AdmissionRepository.Implementation
{
    public class AdmissionRepository(ApplicationDbContext context) : IAdmissionRepository
    {
        public async Task AddAsync(Admission admission)
        {
            await context.Admissions.AddAsync(admission);
        }

        public async Task<List<Admission>> GetAllAsync()
        {
            return await context.Admissions.AsNoTracking().ToListAsync();
        }

        public async Task<Admission?> GetByIdAsync(Guid id)
        {
            return await context.Admissions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsAsync(Guid studentId,Guid trainingProgramId,Guid academicSessionId)
        {
            return await context.Admissions.AnyAsync(x =>
                x.StudentId == studentId &&
                x.TrainingProgramId == trainingProgramId &&
                x.AcademicSessionId == academicSessionId);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}

