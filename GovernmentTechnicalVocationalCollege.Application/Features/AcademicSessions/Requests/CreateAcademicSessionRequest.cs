namespace GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Requests
{
    public record CreateAcademicSessionRequest(
        string Name,
        DateOnly StartDate,
        DateOnly EndDate
        );
}
