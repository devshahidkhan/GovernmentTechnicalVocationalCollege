using GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests;
using GovernmentTechnicalVocationalCollege.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Mappers.StudentMappers
{
    public static class CreateStudentMapper
    {
        public static Student MapToStudent(this CreateStudentRequest request)
        {
            return new Student
            {
               Id = Guid.NewGuid(),
               FirstName = request.FirstName,
               LastName = request.LastName,
               FatherName = request.FatherName,
               CNIC = request.CNIC,
               DateOfBirth = request.DateOfBirth,
               Phone = request.Phone,
               Email = request.Email,
               Address = request.Address,
            };
        }
    }
}
