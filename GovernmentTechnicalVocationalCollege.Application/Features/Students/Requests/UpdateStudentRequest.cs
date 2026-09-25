using GovernmentTechnicalVocationalCollege.Domain.Enums;


namespace GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests
{
    public record UpdateStudentRequest(
        string FirstName,
        string LastName,
        string FatherName,
        string CNIC,
        DateOnly? DateOfBirth,
        Gender? Gender,
        string Phone,
        string? Email,
        string Address,
        string City,
        string? ProfilePhotoUrl
        );
}
