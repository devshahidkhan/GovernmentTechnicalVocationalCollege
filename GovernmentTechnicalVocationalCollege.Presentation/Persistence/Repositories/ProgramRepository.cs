using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Infrastructure.Persistence.Repositories
{
    public class ProgramRepository(ApplicationDbContext context) : IProgramRepository
    {
        public async Task AddProgramAsync(TrainingProgram program)
        {
            await context.Programs.AddAsync(program);
            await context.SaveChangesAsync();
        }
    }
}
