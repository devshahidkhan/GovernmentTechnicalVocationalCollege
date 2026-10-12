using GovernmentTechnicalVocationalCollege.Application.Features.InstructorAssignment.Requests;
using GovernmentTechnicalVocationalCollege.Application.Services.InstructingAssignmentService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GovernmentTechnicalVocationalCollege.ApiGateway.Controllers
{
    [Route("api/instructing-assignments")]
    [ApiController]
    public class TeachingAssignmentsController(IInstructingAssignmentService service) : ControllerBase
    {
        // POST: api/teaching-assignments
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInstructingAssignmentRequest request)
        {
            var response = await service.CreateInstructingAssignmentAsync(request);
            return Ok(response);
        }

        // GET: api/teaching-assignments
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assignments = await service.GetAllAsync();
            return Ok(assignments);
        }

        // GET: api/teaching-assignments/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var assignment = await service.GetByIdAsync(id);

            if (assignment is null)
                return NotFound();

            return Ok(assignment);
        }

        // PUT: api/teaching-assignments/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] UpdateInstructingAssignmentRequest request)
        {
            var response = await service.UpdateInstructingAssignmentAsync(id, request);
            return Ok(response);
        }
    }
}
