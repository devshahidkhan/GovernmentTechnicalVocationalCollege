using GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests;
using GovernmentTechnicalVocationalCollege.Application.Mappers.StudentMappers;
using GovernmentTechnicalVocationalCollege.Application.Services.StudentService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Services.StudentService.Implementation
{
    public class StudentService(IStudentRepository repository) : IStudentService
    {
        public async Task<string> CreateStudentAsync (CreateStudentRequest request)
        {
            var student = request.MapToStudent();
            await repository.AddStudentAsync(student);
            return "Student Saved Successfully!";
        }
    }
}
