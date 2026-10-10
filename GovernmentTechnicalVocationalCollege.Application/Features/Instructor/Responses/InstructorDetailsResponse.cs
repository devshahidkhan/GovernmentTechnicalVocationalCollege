namespace GovernmentTechnicalVocationalCollege.Application.Features.Instructors.Responses;

public record InstructorDetailsResponse(
    Guid Id,
    string EmployeeNo,
    string FirstName,
    string LastName,
    string FatherName,
    string CNIC,
    string Phone,
    string? Email,
    string Address,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);