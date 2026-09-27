using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Responses;
using GovernmentTechnicalVocationalCollege.Application.Mappers.AdmissionMappers;
using GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AcademicSessionRepository.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AdmissionRepository.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository.Interface;

namespace GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Implementation
{
    public class AdmissionService(
        IAdmissionRepository repository,
        IStudentRepository studentRepository,
        IProgramRepository programRepository,
        IAcademicSessionRepository academicSessionRepository)
        : IAdmissionService
    {
        public async Task<AdmissionDetailsResponse> CreateAdmissionAsync(CreateAdmissionRequest request)
        {
            // 1. Validate Student
            var student = await studentRepository.GetByIdAsync(request.StudentId);

            if (student is null)
                throw new InvalidOperationException
                    ("Student does not exist.");

            // 2. Validate Training Program
            var program = await programRepository.GetByIdAsync(request.TrainingProgramId);

            if (program is null)
                throw new InvalidOperationException
                    ("Training program does not exist.");

            // 3. Validate Academic Session
            var session = await academicSessionRepository.GetByIdAsync(request.AcademicSessionId);

            if (session is null)
                throw new InvalidOperationException
                    ("Academic session does not exist.");

            // 4. Prevent duplicate admission
            var exists = await repository.ExistsAsync(
                request.StudentId,
                request.TrainingProgramId,
                request.AcademicSessionId);

            if (exists)
            {
                throw new InvalidOperationException(
                    "An admission already exists for this student, training program and academic session.");
            }

            // 5. Generate business admission number
            var admissionNo = GenerateAdmissionNo(request.ApplicationDate);

            // 6. Map DTO to entity
            var admission = request.MapToEntity(admissionNo);

            // 7. Save
            await repository.AddAsync(admission);
            await repository.SaveChangesAsync();

            // 8. Return created admission
            return admission.MapToDetailsResponse();
        }

        public async Task<List<AdmissionListResponse>> GetAllAsync()
        {
            var admissions = await repository.GetAllAsync();

            return admissions.Select(x => x.MapToListResponse()).ToList();
        }

        public async Task<AdmissionDetailsResponse?> GetByIdAsync(Guid id)
        {
            var admission = await repository.GetByIdAsync(id);

            return admission?.MapToDetailsResponse();
        }

        public async Task<bool> UpdateAdmissionAsync(Guid id,UpdateAdmissionRequest request)
        {
            var admission = await repository.GetByIdAsync(id);

            if (admission is null)
                return false;

            request.MapToEntity(admission);

            await repository.SaveChangesAsync();

            return true;
        }

        private static string GenerateAdmissionNo(DateOnly applicationDate)
        {
            var year = applicationDate.Year;
            var uniquePart = Guid.NewGuid()
                .ToString("N")
                .Substring(0, 8)
                .ToUpperInvariant();

            return $"ADM-{year}-{uniquePart}";
        }
    }
}