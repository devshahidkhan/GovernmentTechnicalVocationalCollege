using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Responces;
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

        public async Task<List<ProgramListResponce>> GetAllProgramsAsync()
        {
            var programs = await repository.GetAllAsync();
            return programs.Select(x => x.MapToListResponce()).ToList();
        }

        public async Task<ProgramDetailsResponce?> GetByIdAsync(Guid id)
        {
            var programs = await repository.GetByIdAsync(id);
            return programs?.MapToDetailsResponce();
        }

        public async Task<string> UpdateProgramAsync(UpdateProgramRequest request,Guid id)
        {
            var program = await repository.GetByIdAsync(id);
            if (program == null)
                return "Program not found";
            await repository.UpdateAsync(program);
            return "Program update succefully!";
        }
    }
}
