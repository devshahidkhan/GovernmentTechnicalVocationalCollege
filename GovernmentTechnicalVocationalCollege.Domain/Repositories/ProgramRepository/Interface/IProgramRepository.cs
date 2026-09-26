using GovernmentTechnicalVocationalCollege.Domain.Entities;


namespace GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface
{
    public interface IProgramRepository
    {
        Task AddProgramAsync(TrainingProgram program);
        Task<List<TrainingProgram>> GetAllAsync();
        Task<TrainingProgram?> GetByIdAsync(Guid id);
        Task UpdateAsync(TrainingProgram program);
    }
}
