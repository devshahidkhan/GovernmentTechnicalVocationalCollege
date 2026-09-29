using GovernmentTechnicalVocationalCollege.Application.Common.APIResponses;
using GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Responces;
using GovernmentTechnicalVocationalCollege.Application.Mappers.AcademicSessionMappers;
using GovernmentTechnicalVocationalCollege.Application.Services.AcademicSessionService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AcademicSessionRepository.Interface;

namespace GovernmentTechnicalVocationalCollege.Application.Services.AcademicSessionService.Implementation
{
    public class AcademicSessionService(IAcademicSessionRepository repository): IAcademicSessionService
    {
        public async Task<ApiResponse<string>>CreateAcademicSessionAsync(CreateAcademicSessionRequest request)
        {
            var academicSession = request.MapToEntity();
            await repository.AddAsync(academicSession);
            await repository.SaveChangesAsync();
            return ApiResponse<string>.Success("AcademicSession saved successfully!");
        }

        public async Task<List<AcademicSessionListResponse>> GetAllAsync()
        {
            var academicSessions = await repository.GetAllAsync();
            return academicSessions.Select(x => x.MapToListResponse()).ToList();
        }

        public async Task<AcademicSessionDetailsResponse?> GetByIdAsync(Guid id)
        {
            var academicSession = await repository.GetByIdAsync(id);
            return academicSession?.MapToDetailsResponse();
        }

        public async Task<ApiResponse<string>> UpdateAcademicSessionAsync(UpdateAcademicSessionRequest request,Guid id)
        {
            var academicSession = await repository.GetByIdAsync(id);

            if (academicSession is null)
                return ApiResponse<string>.Failure("A AcademicSession with this Id does not exists");

            request.MapToEntity(academicSession);

            await repository.SaveChangesAsync();

            return ApiResponse<string>.Failure("AcademicSession has been Updated Successfully!");
        }
    }
}
