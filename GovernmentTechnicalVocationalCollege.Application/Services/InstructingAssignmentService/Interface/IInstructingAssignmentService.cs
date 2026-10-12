using GovernmentTechnicalVocationalCollege.Application.Common.APIResponses;
using GovernmentTechnicalVocationalCollege.Application.Features.InstructorAssignment.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.InstructorAssignment.Responses;

namespace GovernmentTechnicalVocationalCollege.Application.Services.InstructingAssignmentService.Interface
{
    public interface IInstructingAssignmentService
    {
        Task<ApiResponse<string>> CreateInstructingAssignmentAsync(CreateInstructingAssignmentRequest request);

        Task<List<InstructingAssignmentListResponse>> GetAllAsync();

        Task<InstructingAssignmentDetailsResponse?> GetByIdAsync(Guid id);

        Task<ApiResponse<string>> UpdateInstructingAssignmentAsync(Guid id,UpdateInstructingAssignmentRequest request);
    }
}
