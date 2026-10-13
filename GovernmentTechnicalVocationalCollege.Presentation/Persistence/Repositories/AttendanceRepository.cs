using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AttendanceRepository;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GovernmentTechnicalVocationalCollege.Infrastructure.Persistence.Repositories;

public class AttendanceRepository(ApplicationDbContext context):IAttendanceRepository
{
    public async Task AddAsync(Attendance attendance)
    {
        await context.Attendances.AddAsync(attendance);
    }

    public async Task<List<Attendance>> GetAllAsync()
    {
        return await context.Attendances
            .AsNoTracking()
            .Include(x => x.Admission)
                .ThenInclude(x => x.Student)
            .Include(x => x.Admission)
                .ThenInclude(x => x.TrainingProgram)
            .Include(x => x.Admission)
                .ThenInclude(x => x.AcademicSession)
            .Include(x => x.InstructingAssignment)
                .ThenInclude(x => x.Instructor)
            .OrderByDescending(x => x.AttendanceDate)
            .ToListAsync();
    }

    public async Task<Attendance?> GetByIdAsync(Guid id)
    {
        return await context.Attendances
            .Include(x => x.Admission)
                .ThenInclude(x => x.Student)
            .Include(x => x.Admission)
                .ThenInclude(x => x.TrainingProgram)
            .Include(x => x.Admission)
                .ThenInclude(x => x.AcademicSession)
            .Include(x => x.InstructingAssignment)
                .ThenInclude(x => x.Instructor)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsAsync(Guid admissionId,DateOnly attendanceDate,Guid? excludeAttendanceId = null)
    {
        return await context.Attendances.AnyAsync(x =>
            x.AdmissionId == admissionId &&
            x.AttendanceDate == attendanceDate &&
            (!excludeAttendanceId.HasValue ||
             x.Id != excludeAttendanceId.Value));
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}