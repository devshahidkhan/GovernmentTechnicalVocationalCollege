using GovernmentTechnicalVocationalCollege.Application.Common.APIResponses;
using GovernmentTechnicalVocationalCollege.Application.Features.Instructors.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Instructors.Responses;


namespace GovernmentTechnicalVocationalCollege.Application.Services.InstructorService.Interface
{
    public interface IInstructorService
    {
        Task<ApiResponse<string>> CreateInstructorAsync(CreateInstructorRequest request);

        Task<List<InstructorListResponse>> GetAllInstructorsAsync();

        Task<InstructorDetailsResponse?> GetByIdAsync(Guid id);

        Task<ApiResponse<string>> UpdateInstructorAsync(Guid id,UpdateInstructorRequest request);
    }
}
