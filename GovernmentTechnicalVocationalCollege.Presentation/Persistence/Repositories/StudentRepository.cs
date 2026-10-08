using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GovernmentTechnicalVocationalCollege.Infrastructure.Persistence.Repositories;

public class StudentRepository(ApplicationDbContext context)
    : IStudentRepository
{
    public async Task AddAsync(Student student)
    {
        await context.Students.AddAsync(student);
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await context.Students
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await context.Students
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsByCnicAsync(
        string cnic,
        Guid? excludeStudentId = null)
    {
        return await context.Students.AnyAsync(x =>
            x.CNIC == cnic &&
            (!excludeStudentId.HasValue ||
             x.Id != excludeStudentId.Value));
    }

    public async Task<bool> ExistsByPhoneAsync(
        string phone,
        Guid? excludeStudentId = null)
    {
        return await context.Students.AnyAsync(x =>
            x.Phone == phone &&
            (!excludeStudentId.HasValue ||
             x.Id != excludeStudentId.Value));
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}