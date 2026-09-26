using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AcademicSessionRepository.Interface;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace GovernmentTechnicalVocationalCollege.Infrastructure.Persistence.Repositories
{
    public class AcademicSessionRepository(ApplicationDbContext context) : IAcademicSessionRepository
    {
        public async Task AddAsync(AcademicSession session)
        {
            await context.AcademicSessions.AddAsync(session);
            await context.SaveChangesAsync();
        }

        public Task<List<AcademicSession>> GetAllAsync()
        {
            return context.AcademicSessions.AsNoTracking().ToListAsync();
        }

        public async Task<AcademicSession?> GetByIdAsync(Guid id)
        {
            return await context.AcademicSessions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(AcademicSession session)
        {
            context.AcademicSessions.Update(session);
            await context.SaveChangesAsync();
        }
    }
}
