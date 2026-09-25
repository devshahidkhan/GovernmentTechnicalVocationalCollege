using GovernmentTechnicalVocationalCollege.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository.Interface
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(Student student);
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(Guid id);
        Task UpdateStudentAsync(Student student);
    }
}
