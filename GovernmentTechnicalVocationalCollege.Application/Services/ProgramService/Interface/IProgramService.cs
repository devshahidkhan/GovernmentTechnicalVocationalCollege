using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Responses;
using GovernmentTechnicalVocationalCollege.Domain.Entities;


namespace GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Interface
{
    public interface IProgramService
    {
        Task<string> CreateProgramAsync(CreateProgramRequest request);
        Task<List<ProgramListResponse>> GetAllProgramsAsync();
        Task<ProgramDetailsResponse?> GetByIdAsync(Guid id);
        Task<string> UpdateProgramAsync(UpdateProgramRequest program,Guid id);
    }
}
