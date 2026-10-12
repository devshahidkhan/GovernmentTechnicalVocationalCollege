namespace GovernmentTechnicalVocationalCollege.Application.Features.InstructorAssignment.Requests
{
    public record CreateInstructingAssignmentRequest(
        Guid InstructorId,
        Guid TrainingProgramId,
        Guid AcademicSessionId,
        DateOnly AssignedDate
        );
}
