using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Responces;
using GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.ProgramRepository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<IActionResult> GetAll()
        {
            var programs = await service.GetAllProgramsAsync();
            return Ok(programs);
        }

        public async Task<IActionResult> GetById(Guid id) 
        {
            var program = await service.GetByIdAsync(id);
            if (program is null)
                return NotFound();
            return Ok(program);
        }

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
