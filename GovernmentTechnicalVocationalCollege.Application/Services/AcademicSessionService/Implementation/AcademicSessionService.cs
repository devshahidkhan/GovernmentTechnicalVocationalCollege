using GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Responces;
using GovernmentTechnicalVocationalCollege.Application.Mappers.AcademicSessionMappers;
using GovernmentTechnicalVocationalCollege.Application.Services.AcademicSessionService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AcademicSessionRepository.Interface;

namespace GovernmentTechnicalVocationalCollege.Application.Services.AcademicSessionService.Implementation
{
    public class AcademicSessionService(IAcademicSessionRepository repository) : IAcademicSessionService
    {
        public async Task<string> CreateAcademicSessionAsync(CreateAcademicSessionRequest request)
        {
            var academicSession = request.MapToEntity();
            await repository.AddAsync(academicSession);
            return "Academic Session Saved Successfully!";
        }

        public async Task<List<AcademicSessionListResponse>> GetAllAsync()
        {
            var academicSessions = await repository.GetAllAsync();
            return academicSessions.Select(a => a.MapToListResponse()).ToList();
        }

        public async Task<AcademicSessionDetailsResponse?> GetByIdAsync(Guid id)
        {
            var academicSession = await repository.GetByIdAsync(id);
            return academicSession?.MapToDetailsResponse();
        }

        public async Task<string> UpdateAcademicSessionAsync(UpdateAcademicSessionRequest request,Guid id)
        {
            var academicSession = await repository.GetByIdAsync(id);
            if (academicSession == null)
                return "Academic Session is not found";
            request.MapToEntity(academicSession);
            await repository.UpdateAsync(academicSession);
            return "Academic Session Updated Successfully!";
        }
    }
}
