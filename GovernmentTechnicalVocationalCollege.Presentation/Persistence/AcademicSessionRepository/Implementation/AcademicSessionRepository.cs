using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AcademicSessionRepository.Interface;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;


namespace GovernmentTechnicalVocationalCollege.Infrastructure.Persistence.AcademicSessionRepository.Implementation
{
    public class AcademicSessionRepository(ApplicationDbContext context) : IAcademicSessionRepository
    {
        public async Task AddAcademicSessionAsync(AcademicSession session)
        {
            await context.AcademicSessions.AddAsync(session);
            await context.SaveChangesAsync();
        }
    }
}
