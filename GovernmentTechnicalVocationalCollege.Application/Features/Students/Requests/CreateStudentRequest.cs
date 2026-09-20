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
        string Phone,
        string Email,
        string Address
        );
}
