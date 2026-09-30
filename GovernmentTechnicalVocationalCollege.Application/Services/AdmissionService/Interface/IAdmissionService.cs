using GovernmentTechnicalVocationalCollege.Application.Common.APIResponses;
using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Responses;

namespace GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Interface
{
    public interface IAdmissionService
    {
        Task<ApiResponse<string>> CreateAdmissionAsync(CreateAdmissionRequest request);

        Task<List<AdmissionListResponse>> GetAllAsync();

        Task<AdmissionDetailsResponse?> GetByIdAsync(Guid id);

        Task<ApiResponse<string>> UpdateAdmissionAsync(Guid id, UpdateAdmissionRequest request);
    }
}
