using GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Services.StudentService.Interface
{
    public interface IStudentService
    {
        Task<string> CreateStudentAsync (CreateStudentRequest request);
    }
}
