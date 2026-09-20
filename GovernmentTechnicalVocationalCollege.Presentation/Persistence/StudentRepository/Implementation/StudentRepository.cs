using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository.Interface;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Presentation.Persistence.StudentRepository.Implementation
{
    public class StudentRepository(ApplicationDbContext context) : IStudentRepository
    {
        public  async Task AddStudentAsync(Student student)
        {
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
        }
    }
}
