namespace GovernmentTechnicalVocationalCollege.Application.Features.InstructorAssignment.Responses
{
    public record InstructingAssignmentListResponse(
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
        bool IsActive
        );
}
