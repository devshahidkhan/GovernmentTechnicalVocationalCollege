using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository.Interface;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace GovernmentTechnicalVocationalCollege.Infrastructure.Persistence.Repositories
{
    public class StudentRepository(ApplicationDbContext context) : IStudentRepository
    {
        public  async Task AddStudentAsync(Student student)
        {
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await context.Students.AsNoTracking().ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await context.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            context.Students.Update(student);
            await context.SaveChangesAsync();
        }
    }
}
