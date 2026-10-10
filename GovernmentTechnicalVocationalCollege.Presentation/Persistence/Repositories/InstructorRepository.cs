using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.InstructorRepository;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GovernmentTechnicalVocationalCollege.Infrastructure.Persistence.Repositories
{
    public class InstructorRepository(ApplicationDbContext context):IInstructorRepository
    {
        public async Task AddAsync(Instructor instructor)
        {
            await context.Instructors.AddAsync(instructor);
        }

        public async Task<List<Instructor>> GetAllAsync()
        {
            return await context.Instructors.AsNoTracking().ToListAsync();
        }

        public async Task<Instructor?> GetByIdAsync(Guid id)
        {
            return await context.Instructors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsByCnicAsync(string cnic,Guid? excludeInstructorId = null)
        {
            return await context.Instructors.AnyAsync(x =>
                x.CNIC == cnic &&
                (!excludeInstructorId.HasValue ||
                 x.Id != excludeInstructorId.Value));
        }

        public async Task<bool> ExistsByPhoneAsync(string phone,Guid? excludeInstructorId = null)
        {
            return await context.Instructors.AnyAsync(x =>
                x.Phone == phone &&
                (!excludeInstructorId.HasValue ||
                 x.Id != excludeInstructorId.Value));
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
