using GovernmentTechnicalVocationalCollege.Domain.Enums;


namespace GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests
{
    public record CreateProgramRequest(
        string Code,
        string Name,
        int DurationValue,
        DurationUnit DurationUnit,
        string? Description
        );
}
