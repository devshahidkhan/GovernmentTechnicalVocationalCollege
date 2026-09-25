using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace GovernmentTechnicalVocationalCollege.Infrastructure.Persistence.Repositories
{
    public class ProgramRepository(ApplicationDbContext context) : IProgramRepository
    {
        public async Task AddProgramAsync(TrainingProgram program)
        {
            await context.Programs.AddAsync(program);
            await context.SaveChangesAsync();
        }

        public async Task<List<TrainingProgram>> GetAllAsync()
        {
            return await context.Programs.AsNoTracking().ToListAsync();
        }

        public async Task<TrainingProgram?> GetByIdAsync(Guid id)
        {
            return await context.Programs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(TrainingProgram program)
        {
            context.Programs.Update(program);
            await context.SaveChangesAsync();
        }
    }
}
