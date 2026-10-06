using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Responses;
using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Enums;

namespace GovernmentTechnicalVocationalCollege.Application.Mappers.AdmissionMappers
{
    public static class AdmissionMapper
    {
        public static Admission MapToEntity(this CreateAdmissionRequest request,string admissionNo)
        {
            var now = DateTime.UtcNow;

            return new Admission
            {
                Id = Guid.NewGuid(),
                AdmissionNo = admissionNo,

                StudentId = request.StudentId,
                TrainingProgramId = request.TrainingProgramId,
                AcademicSessionId = request.AcademicSessionId,

                ApplicationDate = request.ApplicationDate,
                AdmissionDate = null,

                Status = AdmissionStatus.Pending,

                StatusReason = null,
                Remarks = request.Remarks,

                CreatedAt = now
            };
        }

        public static void MapToEntity(this UpdateAdmissionRequest request,Admission admission)
        {
            admission.AdmissionDate = request.AdmissionDate;
            admission.Status = request.Status;
            admission.StatusReason = request.StatusReason;
            admission.Remarks = request.Remarks;

            admission.UpdatedAt = DateTime.UtcNow;
        }

        public static AdmissionListResponse MapToListResponse( this Admission admission)
        {
            return new AdmissionListResponse(
                admission.Id,
                admission.AdmissionNo,
                admission.StudentId,
                admission.TrainingProgramId,
                admission.AcademicSessionId,
                admission.ApplicationDate,
                admission.AdmissionDate,
                admission.Status
            );
        }

        public static AdmissionDetailsResponse MapToDetailsResponse(this Admission admission)
        {
            return new AdmissionDetailsResponse(
                admission.Id,
                admission.AdmissionNo,
                admission.StudentId,
                admission.TrainingProgramId,
                admission.AcademicSessionId,
                admission.ApplicationDate,
                admission.AdmissionDate,
                admission.Status,
                admission.StatusReason,
                admission.Remarks,
                admission.CreatedAt,
                admission.UpdatedAt
            );
        }
    }
}