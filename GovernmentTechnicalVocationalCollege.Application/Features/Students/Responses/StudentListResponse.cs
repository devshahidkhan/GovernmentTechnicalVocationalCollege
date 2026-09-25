using GovernmentTechnicalVocationalCollege.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Students.Responses
{
    public record StudentListResponse(
        Guid Id,
        string RegistrationNo,
        string FirstName,
        string LastName,
        string FatherName,
        string CNIC,
        string Phone,
        string? Email,
        string City,
        StudentStatus Status
    );
}
