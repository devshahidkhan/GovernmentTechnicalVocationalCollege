using GovernmentTechnicalVocationalCollege.Domain.Entities;

namespace GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface;

public interface IProgramRepository
{
    Task AddAsync(TrainingProgram program);

    Task<List<TrainingProgram>> GetAllAsync();

    Task<TrainingProgram?> GetByIdAsync(Guid id);

    Task<bool> ExistsByCodeAsync(string code);

    Task SaveChangesAsync();
}