using GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Students.Responses;
using GovernmentTechnicalVocationalCollege.Application.Mappers.StudentMappers;
using GovernmentTechnicalVocationalCollege.Application.Services.StudentService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository.Interface;


namespace GovernmentTechnicalVocationalCollege.Application.Services.StudentService.Implementation
{
    public class StudentService(IStudentRepository repository) : IStudentService
    {
        public async Task<string> CreateStudentAsync (CreateStudentRequest request)
        {
            var student = request.MapToEntity();
            await repository.AddStudentAsync(student);
            return "Student Saved Successfully!";
        }

        public async Task<List<StudentListResponse>> GetAllStudentsAsync()
        {
            var students = await repository.GetAllAsync();
            //Take every student, convert it into a StudentListResponse, collect all converted objects into a List, and return that List.
            return students.Select(x => x.MapToListResponse()).ToList();
        }

        public async Task<StudentDetailsResponse?> GetByIdAsync(Guid id)
        {
            var student = await repository.GetByIdAsync(id);
            return student?.MapToDetailsResponse();
        }

        public async Task<string> UpdateStudentAsync(Guid id, UpdateStudentRequest request)
        {
            var student = await repository.GetByIdAsync(id);
            if (student == null)
                return "Student not found";
            request.MapToEntity(student);
            await repository.UpdateStudentAsync(student);
            return "Update Successfully!";
        }
    }
}
