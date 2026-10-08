using GovernmentTechnicalVocationalCollege.Domain.Entities;

namespace GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository;

public interface IStudentRepository
{
    Task AddAsync(Student student);

    Task<List<Student>> GetAllAsync();

    Task<Student?> GetByIdAsync(Guid id);

    Task<bool> ExistsByCnicAsync(
        string cnic,
        Guid? excludeStudentId = null);

    Task<bool> ExistsByPhoneAsync(
        string phone,
        Guid? excludeStudentId = null);

    Task SaveChangesAsync();
}