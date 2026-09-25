using GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests;
using GovernmentTechnicalVocationalCollege.Application.Services.StudentService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GovernmentTechnicalVocationalCollege.ApiGateway.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController(IStudentService service) : ControllerBase
    {
        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreateStudent(CreateStudentRequest request)
        {
            var isSaved = await service.CreateStudentAsync(request);
            return Ok(isSaved);
        }

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await service.GetAllStudentsAsync();
            return Ok(users);
        }

        [HttpGet("GetById/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var student = await service.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut("UpdateStudent/{id:guid}")]
        public async Task<IActionResult> UpdateStudent(Guid id,UpdateStudentRequest request)
        {
            var isUpdate = await service.UpdateStudentAsync(id, request);

            return Ok(new
            {
                message = isUpdate
            });
        }
    }
}
