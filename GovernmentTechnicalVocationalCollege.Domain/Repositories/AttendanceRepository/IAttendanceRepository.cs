using GovernmentTechnicalVocationalCollege.Domain.Entities;

namespace GovernmentTechnicalVocationalCollege.Domain.Repositories.AttendanceRepository
{
    public interface IAttendanceRepository
    {
        Task AddAsync(Attendance attendance);

        Task<List<Attendance>> GetAllAsync();

        Task<Attendance?> GetByIdAsync(Guid id);

        Task<bool> ExistsAsync(Guid admissionId,DateOnly attendanceDate,Guid? excludeAttendanceId = null);

        Task SaveChangesAsync();
    }
}
