namespace GovernmentTechnicalVocationalCollege.Application.Features.Instructors.Responses;

public record InstructorListResponse(
    Guid Id,
    string EmployeeNo,
    string FirstName,
    string LastName,
    string CNIC,
    string Phone,
    bool IsActive
);