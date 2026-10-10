namespace GovernmentTechnicalVocationalCollege.Application.Features.Instructors.Requests;

public record CreateInstructorRequest(
    string FirstName,
    string LastName,
    string FatherName,
    string CNIC,
    string Phone,
    string? Email,
    string Address
);