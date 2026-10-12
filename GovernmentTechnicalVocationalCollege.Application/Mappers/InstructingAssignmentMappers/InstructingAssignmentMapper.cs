using GovernmentTechnicalVocationalCollege.Application.Features.InstructorAssignment.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.InstructorAssignment.Responses;
using GovernmentTechnicalVocationalCollege.Domain.Entities;

namespace GovernmentTechnicalVocationalCollege.Application.Mappers.InstructingAssignmentMappers
{
    public static class InstructingAssignmentMapper
    {
        // Create Request -> TeachingAssignment Entity
        public static InstructingAssignment MapToEntity(this CreateInstructingAssignmentRequest request)
        {
            var now = DateTime.UtcNow;

            return new InstructingAssignment
            {
                Id = Guid.NewGuid(),

                InstructorId = request.InstructorId,
                TrainingProgramId = request.TrainingProgramId,
                AcademicSessionId = request.AcademicSessionId,

                AssignedDate = request.AssignedDate,

                IsActive = true,

                CreatedAt = now,
                UpdatedAt = null
            };
        }

        // Update Request -> Existing TeachingAssignment Entity
        public static void MapToEntity(this UpdateInstructingAssignmentRequest request,InstructingAssignment assignment)
        {
            assignment.IsActive = request.IsActive;
            assignment.UpdatedAt = DateTime.UtcNow;
        }

        // TeachingAssignment Entity -> List Response
        public static InstructingAssignmentListResponse MapToListResponse(this InstructingAssignment assignment)
        {
            return new InstructingAssignmentListResponse(
                assignment.Id,

                assignment.InstructorId,
                assignment.Instructor.EmployeeNo,
                $"{assignment.Instructor.FirstName} {assignment.Instructor.LastName}".Trim(),

                assignment.TrainingProgramId,
                assignment.TrainingProgram.Code,
                assignment.TrainingProgram.Name,

                assignment.AcademicSessionId,
                assignment.AcademicSession.Name,

                assignment.AssignedDate,
                assignment.IsActive
            );
        }

        // TeachingAssignment Entity -> Details Response
        public static InstructingAssignmentDetailsResponse MapToDetailsResponse(this InstructingAssignment assignment)
        {
            return new InstructingAssignmentDetailsResponse(
                assignment.Id,

                assignment.InstructorId,
                assignment.Instructor.EmployeeNo,
                $"{assignment.Instructor.FirstName} {assignment.Instructor.LastName}".Trim(),

                assignment.TrainingProgramId,
                assignment.TrainingProgram.Code,
                assignment.TrainingProgram.Name,

                assignment.AcademicSessionId,
                assignment.AcademicSession.Name,

                assignment.AssignedDate,
                assignment.IsActive,

                assignment.CreatedAt,
                assignment.UpdatedAt
            );
        }
    }
}
