using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GovernmentTechnicalVocationalCollege.Infrastructure.Persistence.Repositories;

public class StudentRepository(ApplicationDbContext context): IStudentRepository
{
    public async Task AddAsync(Student student)
    {
        await context.Students.AddAsync(student);
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await context.Students.AsNoTracking().ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await context.Students.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsByRegistrationNoAsync(string registrationNo)
    {
        return await context.Students.AnyAsync(x => x.RegistrationNo == registrationNo);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByCnicAsync(string cnic)
    {
        return await context.Students.AnyAsync(x => x.CNIC == cnic);
    }

    public async Task<bool> ExistsByPhoneAsync(string phone)
    {
        return await context.Students.AnyAsync(x => x.Phone == phone);
    }
}