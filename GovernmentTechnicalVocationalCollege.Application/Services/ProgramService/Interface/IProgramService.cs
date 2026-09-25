using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Responces;
using GovernmentTechnicalVocationalCollege.Domain.Entities;


namespace GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Interface
{
    public interface IProgramService
    {
        Task<string> CreateProgramAsync(CreateProgramRequest request);
        Task<List<ProgramListResponce>> GetAllProgramsAsync();
        Task<ProgramDetailsResponce?> GetByIdAsync(Guid id);
        Task<string> UpdateProgramAsync(UpdateProgramRequest program,Guid id);
    }
}
