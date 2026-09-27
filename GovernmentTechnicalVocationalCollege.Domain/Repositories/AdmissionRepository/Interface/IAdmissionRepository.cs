using GovernmentTechnicalVocationalCollege.Domain.Entities;

namespace GovernmentTechnicalVocationalCollege.Domain.Repositories.AdmissionRepository.Interface
{
    public interface IAdmissionRepository
    {
        Task AddAsync(Admission admission);

        Task<List<Admission>> GetAllAsync();

        Task<Admission?> GetByIdAsync(Guid id);

        Task<bool> ExistsAsync(
            Guid studentId,
            Guid trainingProgramId,
            Guid academicSessionId,
            Guid? excludeAdmissionId = null);

        Task SaveChangesAsync();
    }
}
