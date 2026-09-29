using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GovernmentTechnicalVocationalCollege.ApiGateway.Controllers;

[Route("api/programs")]
[ApiController]
public class ProgramsController( IProgramService service): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateProgramRequest request)
    {
        var program = await service.CreateProgramAsync(request);
        return Ok(program);
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
    public async Task<IActionResult> Update( Guid id,UpdateProgramRequest request)
    {
        var updated = await service.UpdateProgramAsync(id,request);
        return Ok(updated);
    }
}