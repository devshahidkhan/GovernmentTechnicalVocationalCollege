using GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests;
using GovernmentTechnicalVocationalCollege.Application.Services.StudentService;
using Microsoft.AspNetCore.Mvc;

namespace GovernmentTechnicalVocationalCollege.ApiGateway.Controllers
{

    [Route("api/students")]
    [ApiController]
    public class StudentsController(IStudentService service): ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentRequest request)
        {
            var student = await service.CreateStudentAsync(request);
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await service.GetAllStudentsAsync();

            return Ok(students);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var student = await service.GetByIdAsync(id);

            if (student is null)
                return NotFound();

            return Ok(student);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id,UpdateStudentRequest request)
        {
            var updated = await service.UpdateStudentAsync(id, request);
            return Ok(updated);
        }
    }
}
