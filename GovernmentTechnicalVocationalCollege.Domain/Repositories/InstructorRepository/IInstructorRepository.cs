using GovernmentTechnicalVocationalCollege.Domain.Entities;

namespace GovernmentTechnicalVocationalCollege.Domain.Repositories.InstructorRepository
{
    public interface IInstructorRepository
    {
        Task AddAsync(Instructor instructor);

        Task<List<Instructor>> GetAllAsync();

        Task<Instructor?> GetByIdAsync(Guid id);

        Task<bool> ExistsByCnicAsync(string cnic, Guid? excludeInstructorId = null);

        Task<bool> ExistsByPhoneAsync(string phone,Guid? excludeInstructorId = null);

        Task SaveChangesAsync();
    }
}
