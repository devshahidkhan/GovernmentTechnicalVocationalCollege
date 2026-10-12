namespace GovernmentTechnicalVocationalCollege.Application.Features.InstructorAssignment.Responses
{
    public record InstructingAssignmentDetailsResponse(
        Guid Id,

        Guid InstructorId,
        string EmployeeNo,
        string InstructorName,

        Guid TrainingProgramId,
        string? ProgramCode,
        string? TrainingProgramName,

        Guid AcademicSessionId,
        string AcademicSessionName,

        DateOnly AssignedDate,
        bool IsActive,

        DateTime CreatedAt,
        DateTime? UpdatedAt
        );
}
