using GovernmentTechnicalVocationalCollege.Application.Common.APIResponses;
using GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Students.Responses;
using GovernmentTechnicalVocationalCollege.Application.Mappers.StudentMappers;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.StudentRepository;

namespace GovernmentTechnicalVocationalCollege.Application.Services.StudentService;

public class StudentService(IStudentRepository repository): IStudentService
{
    public async Task<ApiResponse<string>> CreateStudentAsync(CreateStudentRequest request)
    {
        if (await repository.ExistsByCnicAsync(request.CNIC))
        {
            return ApiResponse<string>.Failure("A student with this CNIC already exists.");
        }

        if (await repository.ExistsByPhoneAsync(request.Phone))
        {
            return ApiResponse<string>.Failure("A student with this phone number already exists.");
        }

        var registrationNo = await GenerateRegistrationNoAsync();

        var student = request.MapToEntity(registrationNo); 

        await repository.AddAsync(student);
        await repository.SaveChangesAsync();

        return ApiResponse<string>.Success("Student has been Saved Successfully!");
    }

    public async Task<List<StudentListResponse>> GetAllStudentsAsync()
    {
        var students = await repository.GetAllAsync();

        return students.Select(x => x.MapToListResponse()).ToList();
    }

    public async Task<StudentDetailsResponse?> GetByIdAsync(Guid id)
    {
        var student = await repository.GetByIdAsync(id);

        return student?.MapToDetailsResponse();
    }

    public async Task<ApiResponse<string>> UpdateStudentAsync(Guid id, UpdateStudentRequest request)
    {
        var student = await repository.GetByIdAsync(id);

        if (student is null)
            return ApiResponse<string>.Failure("A student with this Id does not exists."); ;

        if (await repository.ExistsByCnicAsync(request.CNIC))
        {
            return ApiResponse<string>.Failure("A student with this CNIC already exists.");
        }

        if (await repository.ExistsByPhoneAsync(request.Phone))
        {
            return ApiResponse<string>.Failure("A student with this phone number already exists.");
        }

        request.MapToEntity(student);

        await repository.SaveChangesAsync();

        return ApiResponse<string>.Success("Student update successfully");
    }

    private async Task<string> GenerateRegistrationNoAsync()
    {
        // Temporary implementation.
        // Later this should use a dedicated registration-number generator.
        return $"ST-{DateTime.UtcNow:yyyyMMddHHmmss}";
    }
}