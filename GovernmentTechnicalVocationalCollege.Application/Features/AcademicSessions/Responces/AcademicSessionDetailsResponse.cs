namespace GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Responces
{
    public record AcademicSessionDetailsResponse(
        Guid Id,
        string Name,
        DateOnly StartDate,
        DateOnly EndDate,
        bool IsActive,
        DateTime CreatedAt,
        DateTime? UpdatedAt
        );
}
