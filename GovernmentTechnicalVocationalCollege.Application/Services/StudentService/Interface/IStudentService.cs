using GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Students.Responses;
using GovernmentTechnicalVocationalCollege.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Services.StudentService.Interface
{
    public interface IStudentService
    {
        Task<string> CreateStudentAsync (CreateStudentRequest request);
        Task<List<StudentListResponse>> GetAllStudentsAsync();
        Task<StudentDetailsResponse?> GetByIdAsync(Guid id);
        Task<string> UpdateStudentAsync(Guid id, UpdateStudentRequest request);
    }
}
