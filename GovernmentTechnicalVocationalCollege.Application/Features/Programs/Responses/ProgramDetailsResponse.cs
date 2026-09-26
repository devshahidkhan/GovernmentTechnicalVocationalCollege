using GovernmentTechnicalVocationalCollege.Domain.Enums;


namespace GovernmentTechnicalVocationalCollege.Application.Features.Programs.Responses
{
    public record ProgramDetailsResponse(
        Guid Id,
        string Code,
        string Name,
        int DurationValue,
        DurationUnit DurationUnit,
        string? Description,
        bool IsActive,
        DateTime CreatedAt,
        DateTime UpdatedAt
        );
}
