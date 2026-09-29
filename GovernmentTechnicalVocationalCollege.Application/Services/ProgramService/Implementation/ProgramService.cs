using GovernmentTechnicalVocationalCollege.Application.Common.APIResponses;
using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Responses;
using GovernmentTechnicalVocationalCollege.Application.Mappers.ProgramMappers;
using GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface;

namespace GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Implementation;

public class ProgramService(IProgramRepository repository): IProgramService
{
    public async Task<ApiResponse<string>> CreateProgramAsync(CreateProgramRequest request)
    {

        if (await repository.ExistsByCodeAsync(request.Code))
        {
            return ApiResponse<string>.Failure("A program with this Code already exists.");
        }


        var program = request.MapToEntity();

        await repository.AddAsync(program);
        await repository.SaveChangesAsync();
        return ApiResponse<string>.Success("Program has been Saved Successfully!");
    }

    public async Task<List<ProgramListResponse>> GetAllProgramsAsync()
    {
        var programs = await repository.GetAllAsync();

        return programs.Select(x => x.MapToListResponse()).ToList();
    }

    public async Task<ProgramDetailsResponse?> GetByIdAsync(Guid id)
    {
        var program = await repository.GetByIdAsync(id);

        return program?.MapToDetailsResponse();
    }

    public async Task<ApiResponse<string>> UpdateProgramAsync(Guid id,UpdateProgramRequest request)
    {
        var program = await repository.GetByIdAsync(id);

        if (program is null)
           return ApiResponse<string>.Failure("A program with this Id does not exists");

        if (await repository.ExistsByCodeAsync(request.Code))
        {
            return ApiResponse<string>.Failure("A program with this Code already exists.");
        }

        request.MapToEntity(program);
        await repository.SaveChangesAsync();
        return ApiResponse<string>.Failure("Program has been Updated Successfully!");
    }
}