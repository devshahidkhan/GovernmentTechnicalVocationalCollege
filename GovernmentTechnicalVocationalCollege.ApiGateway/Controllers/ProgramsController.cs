using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Responses;
using GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Interface;
using Microsoft.AspNetCore.Mvc;


namespace GovernmentTechnicalVocationalCollege.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController(IProgramService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProgram([FromBody] CreateProgramRequest request)
        {
            var response = await service.CreateProgramAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var programs = await service.GetAllProgramsAsync();
            return Ok(programs);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id) 
        {
            var program = await service.GetByIdAsync(id);
            if (program is null)
                return NotFound();
            return Ok(program);
        }
        
        [HttpPut("{id:guid}")]
        public IActionResult Update(UpdateProgramRequest request,Guid id)
        {
            var update = service.UpdateProgramAsync(request, id);

            return Ok(new
            {
                message = update
            });
        }
    }
}
