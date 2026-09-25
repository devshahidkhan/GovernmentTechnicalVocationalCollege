using GovernmentTechnicalVocationalCollege.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Students.Responses
{
    public record StudentDetailsResponse(
        Guid Id,
        string RegistrationNo,
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
        string? ProfilePhotoUrl,
        StudentStatus Status,
        DateTime CreatedAt,
        DateTime? UpdatedAt
        );
}
