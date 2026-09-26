using GovernmentTechnicalVocationalCollege.Domain.Entities;

namespace GovernmentTechnicalVocationalCollege.Domain.Repositories.AcademicSessionRepository.Interface
{
    public interface IAcademicSessionRepository
    {
        Task AddAsync(AcademicSession session);
        Task<List<AcademicSession>> GetAllAsync();
        Task<AcademicSession?> GetByIdAsync(Guid id);
        Task UpdateAsync(AcademicSession session);
    }
}
