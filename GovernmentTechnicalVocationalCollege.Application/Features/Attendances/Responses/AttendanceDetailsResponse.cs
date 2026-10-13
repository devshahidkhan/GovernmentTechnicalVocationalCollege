using GovernmentTechnicalVocationalCollege.Domain.Enums;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Attendances.Responses
{
    public record AttendanceDetailsResponse(
        Guid Id,

        Guid AdmissionId,
        string AdmissionNo,

        Guid StudentId,
        string RegistrationNo,
        string StudentName,

        Guid InstructingAssignmentId,
        string EmployeeNo,
        string InstructorName,

        string? ProgramCode,
        string? TrainingProgramName,
        string AcademicSessionName,

        DateOnly AttendanceDate,
        AttendanceStatus Status,
        string? Remarks,

        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}
