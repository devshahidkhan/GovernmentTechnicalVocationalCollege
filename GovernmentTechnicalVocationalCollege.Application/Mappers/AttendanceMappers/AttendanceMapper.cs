using GovernmentTechnicalVocationalCollege.Application.Features.Attendances.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Attendances.Responses;
using GovernmentTechnicalVocationalCollege.Domain.Entities;

namespace GovernmentTechnicalVocationalCollege.Application.Mappers.AttendanceMappers
{
    public static class AttendanceMapper
    {
        // Create Request -> Attendance Entity
        public static Attendance MapToEntity(this CreateAttendanceRequest request)
        {
            var now = DateTime.UtcNow;

            return new Attendance
            {
                Id = Guid.NewGuid(),

                AdmissionId = request.AdmissionId,
                InstructingAssignmentId = request.InstructingAssignmentId,

                AttendanceDate = request.AttendanceDate,
                Status = request.Status,
                Remarks = request.Remarks,

                CreatedAt = now,
                UpdatedAt = null
            };
        }

        // Update Request -> Existing Attendance Entity
        public static void MapToEntity( this UpdateAttendanceRequest request,Attendance attendance)
        {
            attendance.AttendanceDate = request.AttendanceDate;
            attendance.Status = request.Status;
            attendance.Remarks = request.Remarks;

            attendance.UpdatedAt = DateTime.UtcNow;
        }

        // Attendance Entity -> List Response
        public static AttendanceListResponse MapToListResponse(this Attendance attendance)
        {
            var admission = attendance.Admission;
            var student = admission.Student;
            var teacher = attendance.InstructingAssignment.Instructor;
            var program = admission.TrainingProgram;
            var session = admission.AcademicSession;

            return new AttendanceListResponse(
                attendance.Id,

                admission.Id,
                admission.AdmissionNo,

                admission.StudentId,
                student.RegistrationNo,
                $"{student.FirstName} {student.LastName}".Trim(),

                attendance.InstructingAssignmentId,
                teacher.EmployeeNo,
                $"{teacher.FirstName} {teacher.LastName}".Trim(),

                program.Code,
                program.Name,
                session.Name,

                attendance.AttendanceDate,
                attendance.Status
            );
        }

        // Attendance Entity -> Details Response
        public static AttendanceDetailsResponse MapToDetailsResponse(this Attendance attendance)
        {
            var admission = attendance.Admission;
            var student = admission.Student;
            var teacher = attendance.InstructingAssignment.Instructor;
            var program = admission.TrainingProgram;
            var session = admission.AcademicSession;

            return new AttendanceDetailsResponse(
                attendance.Id,

                admission.Id,
                admission.AdmissionNo,

                admission.StudentId,
                student.RegistrationNo,
                $"{student.FirstName} {student.LastName}".Trim(),

                attendance.InstructingAssignmentId,
                teacher.EmployeeNo,
                $"{teacher.FirstName} {teacher.LastName}".Trim(),

                program.Code,
                program.Name,
                session.Name,

                attendance.AttendanceDate,
                attendance.Status,
                attendance.Remarks,

                attendance.CreatedAt,
                attendance.UpdatedAt
            );
        }
    }
}
