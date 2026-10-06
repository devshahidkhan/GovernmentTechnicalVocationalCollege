using GovernmentTechnicalVocationalCollege.Domain.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests
{
    public record CreateStudentRequest(
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
        DateTime CreatedAt
        );
}
