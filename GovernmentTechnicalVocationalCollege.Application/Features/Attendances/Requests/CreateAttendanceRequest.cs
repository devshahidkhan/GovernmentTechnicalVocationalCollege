using GovernmentTechnicalVocationalCollege.Domain.Enums;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Attendances.Requests
{
    public record CreateAttendanceRequest(
        Guid AdmissionId,
        Guid InstructingAssignmentId,
        DateOnly AttendanceDate,
        AttendanceStatus Status,
        string? Remarks
    );
}
