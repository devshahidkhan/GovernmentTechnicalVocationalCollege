using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GovernmentTechnicalVocationalCollege.Infrastructure.Persistence.Repositories;

public class ProgramRepository(ApplicationDbContext context): IProgramRepository
{
    public async Task AddAsync(TrainingProgram program)
    {
        await context.Programs.AddAsync(program);
    }

    public async Task<List<TrainingProgram>> GetAllAsync()
    {
        return await context.Programs.AsNoTracking().ToListAsync();
    }

    public async Task<TrainingProgram?> GetByIdAsync(Guid id)
    {
        return await context.Programs.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsByCodeAsync( string code)
    {
        return await context.Programs.AnyAsync(x => x.Code == code); 
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
