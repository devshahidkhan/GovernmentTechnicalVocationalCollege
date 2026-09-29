using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AcademicSessionRepository.Interface;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace GovernmentTechnicalVocationalCollege.Infrastructure.Persistence.Repositories
{
    public class AcademicSessionRepository(ApplicationDbContext context): IAcademicSessionRepository
    {
        public async Task AddAsync(AcademicSession session)
        {
            await context.AcademicSessions.AddAsync(session);
        }

        public async Task<List<AcademicSession>> GetAllAsync()
        {
            return await context.AcademicSessions.AsNoTracking().ToListAsync();
        }

        public async Task<AcademicSession?> GetByIdAsync(Guid id)
        {
            return await context.AcademicSessions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
