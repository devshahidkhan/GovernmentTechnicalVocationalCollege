using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using GovernmentTechnicalVocationalCollege.Application.Mappers.ProgramMappers;
using GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface;


namespace GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Implementation
{
    public class ProgramService(IProgramRepository repository) : IProgramService
    {
        public async Task<string> CreateProgramAsync(CreateProgramRequest request)
        {
            var program =  request.MapToEntity();
            await repository.AddProgramAsync(program);
            return "Add Program Successfully!";
        }
    }
}
