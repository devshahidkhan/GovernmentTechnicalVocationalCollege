using GovernmentTechnicalVocationalCollege.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository.Interface
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(Student student); 
    }
}
