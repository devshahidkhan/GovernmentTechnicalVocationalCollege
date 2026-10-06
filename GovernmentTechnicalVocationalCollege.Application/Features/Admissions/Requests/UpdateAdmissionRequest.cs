using GovernmentTechnicalVocationalCollege.Domain.Enums;
namespace GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests
{
    public record UpdateAdmissionRequest(
        DateOnly? AdmissionDate,
        AdmissionStatus Status,
        string? StatusReason,
        string? Remarks
        );
}
