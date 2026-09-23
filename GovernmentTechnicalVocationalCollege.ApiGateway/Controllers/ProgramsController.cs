using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GovernmentTechnicalVocationalCollege.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController(IProgramService service) : ControllerBase
    {
        [HttpPost("CreateProgram")]
        public async Task<IActionResult> CreateProgram([FromBody] CreateProgramRequest request)
        {
            var response = await service.CreateProgramAsync(request);
            return Ok(response);
        }
    }
}
