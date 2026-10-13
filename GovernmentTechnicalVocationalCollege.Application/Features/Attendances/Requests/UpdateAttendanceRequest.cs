using GovernmentTechnicalVocationalCollege.Domain.Enums;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Attendances.Requests
{
    public record UpdateAttendanceRequest(
        DateOnly AttendanceDate,
        AttendanceStatus Status,
        string? Remarks
    );
}
