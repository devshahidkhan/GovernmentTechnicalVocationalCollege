using GovernmentTechnicalVocationalCollege.Application.Common.APIResponses;
using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Responses;
using GovernmentTechnicalVocationalCollege.Application.Mappers.AdmissionMappers;
using GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AcademicSessionRepository.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AdmissionRepository.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository;


namespace GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Implementation
{
    public class AdmissionService(IAdmissionRepository repository, IStudentRepository studentRepository,  IProgramRepository programRepository,IAcademicSessionRepository academicSessionRepository): IAdmissionService
    {
        public async Task<ApiResponse<string>> CreateAdmissionAsync(CreateAdmissionRequest request)
        {
            // 1. Validate Student
            var student = await studentRepository.GetByIdAsync(request.StudentId);

            if (student is null)
                ApiResponse<string>.Failure("Student does not exist.");

            // 2. Validate Training Program
            var program = await programRepository.GetByIdAsync(request.TrainingProgramId);

            if (program is null)
                ApiResponse<string>.Failure("Training program does not exist.");

            // 3. Validate Academic Session
            var session = await academicSessionRepository.GetByIdAsync(request.AcademicSessionId);

            if (session is null)
               ApiResponse<string>.Failure("Academic session does not exist.");

            // 4. Prevent duplicate admission
            var exists = await repository.ExistsAsync(
                request.StudentId,
                request.TrainingProgramId,
                request.AcademicSessionId);

            if (exists)
            {
               ApiResponse<string>.Failure("An admission already exists for this student, training program and academic session.");
            }

            // 5. Generate business admission number
            var admissionNo = GenerateAdmissionNo(request.ApplicationDate);

            // 6. Map DTO to entity
            var admission = request.MapToEntity(admissionNo);

            // 7. Save
            await repository.AddAsync(admission);
            await repository.SaveChangesAsync();
            return ApiResponse<string>.Success("Admission of student created successfully!");

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

        public async Task<ApiResponse<string>> UpdateAdmissionAsync(Guid id,UpdateAdmissionRequest request)
        {
            var admission = await repository.GetByIdAsync(id);

            if (admission is null)
                return ApiResponse<string>.Failure("A Admission with this Id does not exiss.");

            request.MapToEntity(admission);

            await repository.SaveChangesAsync();

            return ApiResponse<string>.Success("A student Admission has update successfully!");
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