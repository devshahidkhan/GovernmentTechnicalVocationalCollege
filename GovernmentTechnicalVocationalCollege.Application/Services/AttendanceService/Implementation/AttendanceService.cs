using GovernmentTechnicalVocationalCollege.Application.Common.APIResponses;
using GovernmentTechnicalVocationalCollege.Application.Features.Attendances.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Attendances.Responses;
using GovernmentTechnicalVocationalCollege.Application.Mappers.AttendanceMappers;
using GovernmentTechnicalVocationalCollege.Application.Services.AttendanceService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Enums;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AdmissionRepository.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AttendanceRepository;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.InstructingAssignmentRepository;

namespace GovernmentTechnicalVocationalCollege.Application.Services.AttendanceService.Implementation
{
    public class AttendanceService(
            IAttendanceRepository repository,
            IAdmissionRepository admissionRepository,
            IInstructingAssignmentRepository instructingAssignmentRepository)
            : IAttendanceService
    {
        public async Task<ApiResponse<string>> CreateAttendanceAsync(CreateAttendanceRequest request)
        {
            // 1. Verify that the admission exists.
            var admission = await admissionRepository.GetByIdAsync(request.AdmissionId);

            if (admission is null)
            {
                return ApiResponse<string>.Failure("Admission does not exist.");
            }

            // 2. Only active admissions may receive new attendance records.
            if (admission.Status != AdmissionStatus.Active)
            {
                return ApiResponse<string>.Failure("Attendance can only be recorded for an active admission.");
            }

            // 3. Verify that the teaching assignment exists.
            var assignment = await instructingAssignmentRepository.GetByIdAsync(request.InstructingAssignmentId);

            if (assignment is null)
            {
                return ApiResponse<string>.Failure("Instructing assignment does not exist.");
            }

            // 4. Verify that the assignment is active.
            if (!assignment.IsActive)
            {
                return ApiResponse<string>.Failure("Attendance cannot be recorded using an inactive instructing assignment.");
            }

            // 5. Verify that the teacher is active.
            if (!assignment.Instructor.IsActive)
            {
                return ApiResponse<string>.Failure("The assigned instructor is inactive.");
            }

            // 6. Ensure the assignment matches the student's admission.
            if (assignment.TrainingProgramId != admission.TrainingProgramId ||
                assignment.AcademicSessionId != admission.AcademicSessionId)

            {
                return ApiResponse<string>.Failure("The instructing assignment does not match the admission's training program and academic session.");
            }

            // 7. Prevent duplicate attendance for the same admission and date.
            var alreadyExists = await repository.ExistsAsync(request.AdmissionId,request.AttendanceDate);

            if (alreadyExists)
            {
                return ApiResponse<string>.Failure("Attendance has already been recorded for this admission on this date.");
            }

            // 8. Map request to entity.
            var attendance = request.MapToEntity();

            // 9. Save attendance.
            await repository.AddAsync(attendance);
            await repository.SaveChangesAsync();
            return ApiResponse<string>.Success("Student attendance recorded successfully.");
        }

        public async Task<List<AttendanceListResponse>> GetAllAsync()
        {
            var attendances = await repository.GetAllAsync();
            return attendances.Select(x => x.MapToListResponse()).ToList();
        }

        public async Task<AttendanceDetailsResponse?> GetByIdAsync(Guid id)
        {
            var attendance = await repository.GetByIdAsync(id);
            return attendance?.MapToDetailsResponse();
        }

        public async Task<ApiResponse<string>> UpdateAttendanceAsync(Guid id, UpdateAttendanceRequest request)
        {
            // 1. Find the existing attendance record.
            var attendance = await repository.GetByIdAsync(id);

            if (attendance is null)
            {
                return ApiResponse<string>.Failure("Attendance record does not exist.");
            }

            // 2. Prevent duplicate attendance if the date changes.
            var alreadyExists = await repository.ExistsAsync(attendance.AdmissionId, request.AttendanceDate,id);

            if (alreadyExists)
            {
                return ApiResponse<string>.Failure("Attendance already exists for this admission on the selected date.");
            }

            // 3. Update the existing tracked entity.
            request.MapToEntity(attendance);
            await repository.SaveChangesAsync();
            return ApiResponse<string>.Success("Attendance updated successfully.");
        }
    }
}
