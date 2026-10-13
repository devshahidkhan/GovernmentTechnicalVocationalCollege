using GovernmentTechnicalVocationalCollege.Application.Common.APIResponses;
using GovernmentTechnicalVocationalCollege.Application.Features.Attendances.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Attendances.Responses;

namespace GovernmentTechnicalVocationalCollege.Application.Services.AttendanceService.Interface
{
    public interface IAttendanceService
    {
        Task<ApiResponse<string>> CreateAttendanceAsync(CreateAttendanceRequest request);

        Task<List<AttendanceListResponse>> GetAllAsync();

        Task<AttendanceDetailsResponse?> GetByIdAsync(Guid id);

        Task<ApiResponse<string>> UpdateAttendanceAsync(Guid id,UpdateAttendanceRequest request);
    }
}
