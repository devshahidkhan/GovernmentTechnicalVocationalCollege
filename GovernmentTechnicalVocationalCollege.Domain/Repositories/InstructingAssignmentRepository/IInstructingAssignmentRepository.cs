using GovernmentTechnicalVocationalCollege.Domain.Entities;

namespace GovernmentTechnicalVocationalCollege.Domain.Repositories.InstructingAssignmentRepository
{
    public interface IInstructingAssignmentRepository
    {
        Task AddAsync(InstructingAssignment assignment);

        Task<List<InstructingAssignment>> GetAllAsync();

        Task<InstructingAssignment?> GetByIdAsync(Guid id);

        Task<bool> HasActiveAssignmentAsync(
            Guid trainingProgramId,
            Guid academicSessionId,
            Guid? excludeAssignmentId = null);

        Task SaveChangesAsync();
    }
}
