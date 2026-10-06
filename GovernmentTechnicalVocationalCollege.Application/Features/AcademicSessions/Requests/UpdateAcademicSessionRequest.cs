namespace GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Requests
{
    public record UpdateAcademicSessionRequest(
        string Name,
        DateOnly StartDate,
        DateOnly EndDate,
        bool IsActive
        );
}
