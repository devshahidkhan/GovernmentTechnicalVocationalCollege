using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Responses;

namespace GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Interface
{
    public interface IAdmissionService
    {
        Task<AdmissionDetailsResponse> CreateAdmissionAsync(CreateAdmissionRequest request);

        Task<List<AdmissionListResponse>> GetAllAsync();

        Task<AdmissionDetailsResponse?> GetByIdAsync(Guid id);

        Task<bool> UpdateAdmissionAsync(Guid id, UpdateAdmissionRequest request);
    }
}
