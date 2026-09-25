using GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Students.Responses;
using GovernmentTechnicalVocationalCollege.Domain.Entities;


namespace GovernmentTechnicalVocationalCollege.Application.Mappers.StudentMappers
{
    public static class StudentMapper
    {
        public static Student MapToEntity(this CreateStudentRequest request/*string registrationNo*/)
        {
            return new Student
            {
                Id = Guid.NewGuid(),
                //RegistrationNo = registrationNo,

                FirstName = request.FirstName,
                LastName = request.LastName,
                FatherName = request.FatherName,
                CNIC = request.CNIC,

                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,

                Phone = request.Phone,
                Email = request.Email,

                Address = request.Address,
                City = request.City
            };
        }

        public static void MapToEntity(this UpdateStudentRequest request,Student student)
        {
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.FatherName = request.FatherName;
            student.CNIC = request.CNIC;

            student.DateOfBirth = request.DateOfBirth;
            student.Gender = request.Gender;

            student.Phone = request.Phone;
            student.Email = request.Email;

            student.Address = request.Address;
            student.City = request.City;
            student.ProfilePhotoUrl = request.ProfilePhotoUrl;

            student.UpdatedAt = DateTime.UtcNow;
        }

        public static StudentListResponse MapToListResponse(this Student student)
        {
            return new StudentListResponse(
                student.Id,
                student.RegistrationNo,
                student.FirstName,
                student.LastName,
                student.FatherName,
                student.CNIC,
                student.Phone,
                student.Email,
                student.City,
                student.Status
            );
        }

        public static StudentDetailsResponse MapToDetailsResponse(this Student student)
        {
            return new StudentDetailsResponse(
                student.Id,
                student.RegistrationNo,
                student.FirstName,
                student.LastName,
                student.FatherName,
                student.CNIC,
                student.DateOfBirth,
                student.Gender,
                student.Phone,
                student.Email,
                student.Address,
                student.City,
                student.ProfilePhotoUrl,
                student.Status,
                student.CreatedAt,
                student.UpdatedAt
            );
        }
    }
}
