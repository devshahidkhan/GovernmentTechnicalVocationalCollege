using GovernmentTechnicalVocationalCollege.Application.Common.APIResponses;
using GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Students.Responses;

namespace GovernmentTechnicalVocationalCollege.Application.Services.StudentService;

public interface IStudentService
{
    Task<ApiResponse<string>> CreateStudentAsync(CreateStudentRequest request);

    Task<List<StudentListResponse>> GetAllStudentsAsync();

    Task<StudentDetailsResponse?> GetByIdAsync(Guid id);

    Task<ApiResponse<string>> UpdateStudentAsync(Guid id,UpdateStudentRequest request);
}