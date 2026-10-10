using GovernmentTechnicalVocationalCollege.Application.Features.Instructors.Requests;
using GovernmentTechnicalVocationalCollege.Application.Services.InstructorService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GovernmentTechnicalVocationalCollege.ApiGateway.Controllers
{
    [Route("api/instructor")]
    [ApiController]
    public class InstructorController(IInstructorService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInstructorRequest request)
        {
            var response = await service.CreateInstructorAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await service.GetAllInstructorsAsync();
            return Ok(teachers);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var teacher = await service.GetByIdAsync(id);

            if (teacher is null)
                return NotFound();

            return Ok(teacher);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] UpdateInstructorRequest request)
        {
            var response = await service.UpdateInstructorAsync(id, request);
            return Ok(response);
        }
    }
}
