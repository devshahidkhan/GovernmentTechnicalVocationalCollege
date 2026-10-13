using GovernmentTechnicalVocationalCollege.Domain.Enums;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Attendances.Responses
{
    public record AttendanceListResponse(
        Guid Id,

        Guid AdmissionId,
        string AdmissionNo,

        Guid StudentId,
        string RegistrationNo,
        string StudentName,

        Guid InstructingAssignmentId,
        string EmployeeNo,
        string TeacherName,

        string? ProgramCode,
        string? TrainingProgramName,
        string AcademicSessionName,

        DateOnly AttendanceDate,
        AttendanceStatus Status
    );
}
