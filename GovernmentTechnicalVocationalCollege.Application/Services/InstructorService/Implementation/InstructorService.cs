using GovernmentTechnicalVocationalCollege.Application.Common.APIResponses;
using GovernmentTechnicalVocationalCollege.Application.Features.Instructors.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Instructors.Responses;
using GovernmentTechnicalVocationalCollege.Application.Mappers.InstructorMappers;
using GovernmentTechnicalVocationalCollege.Application.Services.InstructorService.Interface;
using GovernmentTechnicalVocationalCollege.Application.Services.NumberGenerationService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.InstructorRepository;

namespace GovernmentTechnicalVocationalCollege.Application.Services.InstructorService.Implementation
{
    public class InstructorService(IInstructorRepository repository,INumberGeneratorService numberGeneratorService) : IInstructorService
    {
        public async Task<ApiResponse<string>> CreateInstructorAsync(CreateInstructorRequest request)
        {
            // Check duplicate CNIC
            if (await repository.ExistsByCnicAsync(request.CNIC))
            {
                return ApiResponse<string>.Failure(
                    "A instructor with this CNIC already exists.");
            }

            // Check duplicate phone number
            if (await repository.ExistsByPhoneAsync(request.Phone))
            {
                return ApiResponse<string>.Failure(
                    "A instructor with this phone number already exists.");
            }

            // Generate employee number
            var year = DateTime.UtcNow.Year;

            var employeeNo = await numberGeneratorService.GenerateEmployeeNoAsync(year);

            // Map request to entity
            var instructor = request.MapToEntity(employeeNo);

            // Save teacher
            await repository.AddAsync(instructor);
            await repository.SaveChangesAsync();

            return ApiResponse<string>.Success($"instructor saved successfully. Employee No: {employeeNo}");
        }

        public async Task<List<InstructorListResponse>> GetAllInstructorsAsync()
        {
            var instructors = await repository.GetAllAsync();
            return instructors.Select(x => x.MapToListResponse()).ToList();
        }

        public async Task<InstructorDetailsResponse?> GetByIdAsync(Guid id)
        {
            var teacher = await repository.GetByIdAsync(id);
            return teacher?.MapToDetailsResponse();
        }

        public async Task<ApiResponse<string>> UpdateInstructorAsync(Guid id,UpdateInstructorRequest request)
        {
            // Find existing teacher
            var instructor = await repository.GetByIdAsync(id);

            if (instructor is null)
            {
                return ApiResponse<string>.Failure("Instructor with this ID does not exist.");
            }

            // Exclude the current teacher when checking duplicates
            if (await repository.ExistsByCnicAsync(request.CNIC, id))
            {
                return ApiResponse<string>.Failure("Another instructor with this CNIC already exists.");
            }

            if (await repository.ExistsByPhoneAsync(request.Phone, id))
            {
                return ApiResponse<string>.Failure("Another instructor with this phone number already exists.");
            }

            // Update the tracked entity
            request.MapToEntity(instructor);

            await repository.SaveChangesAsync();

            return ApiResponse<string>.Success("Instructor updated successfully.");
        }
    }
}
