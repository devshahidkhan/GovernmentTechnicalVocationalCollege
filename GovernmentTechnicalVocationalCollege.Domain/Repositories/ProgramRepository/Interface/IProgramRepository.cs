using GovernmentTechnicalVocationalCollege.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
