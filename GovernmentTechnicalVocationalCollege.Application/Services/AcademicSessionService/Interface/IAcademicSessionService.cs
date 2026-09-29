using GovernmentTechnicalVocationalCollege.Application.Common.APIResponses;
using GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Responces;

namespace GovernmentTechnicalVocationalCollege.Application.Services.AcademicSessionService.Interface
{
    public interface IAcademicSessionService
    {
        Task<ApiResponse<string>> CreateAcademicSessionAsync(CreateAcademicSessionRequest request);

        Task<List<AcademicSessionListResponse>> GetAllAsync();

        Task<AcademicSessionDetailsResponse?> GetByIdAsync(Guid id);

        Task<ApiResponse<string>> UpdateAcademicSessionAsync( UpdateAcademicSessionRequest request,Guid id);
    }
}
