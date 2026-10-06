namespace GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Responces
{
    public record AcademicSessionListResponse(
        Guid Id,
        string Name,
        DateOnly StartDate,
        DateOnly EndDate,
        bool IsActive
        );
}
