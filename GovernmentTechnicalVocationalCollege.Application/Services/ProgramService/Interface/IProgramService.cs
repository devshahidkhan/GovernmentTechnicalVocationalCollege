using GovernmentTechnicalVocationalCollege.Application.Common.APIResponses;
using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Responses;

namespace GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Interface;

public interface IProgramService
{
    Task<ApiResponse<string>> CreateProgramAsync(CreateProgramRequest request);

    Task<List<ProgramListResponse>> GetAllProgramsAsync();

    Task<ProgramDetailsResponse?> GetByIdAsync(Guid id);

    Task<ApiResponse<string>> UpdateProgramAsync(Guid id, UpdateProgramRequest request);
}