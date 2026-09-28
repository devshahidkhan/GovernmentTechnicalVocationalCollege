using GovernmentTechnicalVocationalCollege.Domain.Entities;

namespace GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository;

public interface IStudentRepository
{
    Task AddAsync(Student student);

    Task<List<Student>> GetAllAsync();

    Task<Student?> GetByIdAsync(Guid id);

    Task<bool> ExistsByRegistrationNoAsync( string registrationNo);

    Task SaveChangesAsync();

    Task<bool> ExistsByCnicAsync(string cnic);
    Task<bool> ExistsByPhoneAsync(string phone);
}