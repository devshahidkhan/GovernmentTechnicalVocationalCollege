using GovernmentTechnicalVocationalCollege.Application.Common.APIResponses;
using GovernmentTechnicalVocationalCollege.Application.Features.InstructorAssignment.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.InstructorAssignment.Responses;
using GovernmentTechnicalVocationalCollege.Application.Mappers.InstructingAssignmentMappers;
using GovernmentTechnicalVocationalCollege.Application.Services.InstructingAssignmentService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AcademicSessionRepository.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.InstructingAssignmentRepository;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.InstructorRepository;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface;


namespace GovernmentTechnicalVocationalCollege.Application.Services.InstructingAssignmentService.Implementation
{
    public class InstructingAssignmentService(
        IInstructingAssignmentRepository repository,
        IInstructorRepository instructorRepository,
        IProgramRepository programRepository,
        IAcademicSessionRepository academicSessionRepository) : IInstructingAssignmentService
    {
        public async Task<ApiResponse<string>> CreateInstructingAssignmentAsync(CreateInstructingAssignmentRequest request)
        {
            // 1. Check whether the instructor exists.
            var instructor = await instructorRepository.GetByIdAsync(
                request.InstructorId);

            if (instructor is null)
            {
                return ApiResponse<string>.Failure(
                    "Instructor does not exist.");
            }

            if (!instructor.IsActive)
            {
                return ApiResponse<string>.Failure(
                    "An inactive instructor cannot receive a new active assignment.");
            }

            // 2. Check whether the training program exists.
            var program = await programRepository.GetByIdAsync(
                request.TrainingProgramId);

            if (program is null)
            {
                return ApiResponse<string>.Failure(
                    "Training program does not exist.");
            }

            if (!program.IsActive)
            {
                return ApiResponse<string>.Failure(
                    "An inactive training program cannot receive an active assignment.");
            }

            // 3. Check whether the academic session exists.
            var session = await academicSessionRepository.GetByIdAsync(
                request.AcademicSessionId);

            if (session is null)
            {
                return ApiResponse<string>.Failure(
                    "Academic session does not exist.");
            }

            // 4. Prevent multiple active assignments for the same
            // training program and academic session.
            var hasActiveAssignment =
                await repository.HasActiveAssignmentAsync(
                    request.TrainingProgramId,
                    request.AcademicSessionId);

            if (hasActiveAssignment)
            {
                return ApiResponse<string>.Failure(
                    "An active teacher is already assigned to this training program for this academic session. Deactivate the existing assignment first.");
            }

            // 5. Map the request to the entity.
            var assignment = request.MapToEntity();

            // 6. Save the assignment.
            await repository.AddAsync(assignment);
            await repository.SaveChangesAsync();

            return ApiResponse<string>.Success(
                "Instructing assignment created successfully.");
        }

        public async Task<List<InstructingAssignmentListResponse>> GetAllAsync()
        {
            var assignments = await repository.GetAllAsync();

            return assignments.Select(x => x.MapToListResponse()).ToList();
        }

        public async Task<InstructingAssignmentDetailsResponse?> GetByIdAsync(Guid id)
        {
            var assignment = await repository.GetByIdAsync(id);

            return assignment?.MapToDetailsResponse();
        }

        public async Task<ApiResponse<string>> UpdateInstructingAssignmentAsync(Guid id, UpdateInstructingAssignmentRequest request)
        {
            // 1. Find the existing assignment.
            var assignment = await repository.GetByIdAsync(id);

            if (assignment is null)
            {
                return ApiResponse<string>.Failure(
                    "Instructing assignment does not exist.");
            }

            // 2. Only perform additional checks when activating.
            if (request.IsActive)
            {
                var instructor = await instructorRepository.GetByIdAsync(
                    assignment.InstructorId);

                if (instructor is null || !instructor.IsActive)
                {
                    return ApiResponse<string>.Failure(
                        "The assigned instructor does not exist or is inactive.");
                }

                var program = await programRepository.GetByIdAsync(
                    assignment.TrainingProgramId);

                if (program is null || !program.IsActive)
                {
                    return ApiResponse<string>.Failure(
                        "The assigned training program does not exist or is inactive.");
                }

                // Exclude this assignment from the duplicate check.
                var hasAnotherActiveAssignment =
                    await repository.HasActiveAssignmentAsync(
                        assignment.TrainingProgramId,
                        assignment.AcademicSessionId,
                        assignment.Id);

                if (hasAnotherActiveAssignment)
                {
                    return ApiResponse<string>.Failure(
                        "Another active instuctor assignment already exists for this training program and academic session.");
                }
            }

            // 3. Map changes onto the tracked entity.
            request.MapToEntity(assignment);

            // 4. Save changes.
            await repository.SaveChangesAsync();

            return ApiResponse<string>.Success(
                request.IsActive
                    ? "Instucting assignment activated successfully."
                    : "Instucting assignment deactivated successfully.");
        }
    }
}

