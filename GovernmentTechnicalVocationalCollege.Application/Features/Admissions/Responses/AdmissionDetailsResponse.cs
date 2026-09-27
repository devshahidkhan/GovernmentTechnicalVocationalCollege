using GovernmentTechnicalVocationalCollege.Domain.Enums;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Responses
{
    public record AdmissionDetailsResponse(
        Guid Id,
        string AdmissionNo,
        Guid StudentId,
        Guid TrainingProgramId,
        Guid AcademicSessionId,
        DateOnly ApplicationDate,
        DateOnly? AdmissionDate,
        AdmissionStatus Status,
        string? StatusReason,
        string? Remarks,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}
