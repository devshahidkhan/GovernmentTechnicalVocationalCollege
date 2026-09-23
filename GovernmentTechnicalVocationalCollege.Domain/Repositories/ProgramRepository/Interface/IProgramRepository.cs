using GovernmentTechnicalVocationalCollege.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface
{
    public interface IProgramRepository
    {
        Task AddProgramAsync(TrainingProgram program);
    }
}
