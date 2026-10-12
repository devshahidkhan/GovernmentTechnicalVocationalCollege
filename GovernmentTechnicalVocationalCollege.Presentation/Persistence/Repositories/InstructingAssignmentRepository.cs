using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.InstructingAssignmentRepository;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GovernmentTechnicalVocationalCollege.Infrastructure.Persistence.Repositories
{
    public class InstructingAssignmentRepository(ApplicationDbContext context) : IInstructingAssignmentRepository
    {
        public async Task AddAsync(InstructingAssignment assignment)
        {
            await context.InstructingAssignments.AddAsync(assignment);
        }

        public async Task<List<InstructingAssignment>> GetAllAsync()
        {
            return await context.InstructingAssignments
           .AsNoTracking()
           .Include(x => x.Instructor)
           .Include(x => x.TrainingProgram)
           .Include(x => x.AcademicSession)
           .OrderByDescending(x => x.AssignedDate)
            .ToListAsync();
        }

        public async Task<InstructingAssignment?> GetByIdAsync(Guid id)
        {
            return await context.InstructingAssignments
            .Include(x => x.Instructor)
            .Include(x => x.TrainingProgram)
            .Include(x => x.AcademicSession)
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> HasActiveAssignmentAsync(Guid trainingProgramId, Guid academicSessionId, Guid? excludeAssignmentId = null)
        {
            return await context.InstructingAssignments
            .AnyAsync(x =>
            x.TrainingProgramId == trainingProgramId &&
            x.AcademicSessionId == academicSessionId &&
            x.IsActive &&
            (!excludeAssignmentId.HasValue ||
            x.Id != excludeAssignmentId.Value));
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
