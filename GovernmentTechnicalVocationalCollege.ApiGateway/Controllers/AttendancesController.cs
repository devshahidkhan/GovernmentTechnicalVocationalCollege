using GovernmentTechnicalVocationalCollege.Application.Features.Attendances.Requests;
using GovernmentTechnicalVocationalCollege.Application.Services.AttendanceService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GovernmentTechnicalVocationalCollege.ApiGateway.Controllers;

[Route("api/attendances")]
[ApiController]
public class AttendancesController(IAttendanceService service) : ControllerBase
{
    // POST: api/attendances
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAttendanceRequest request)
    {
        var response = await service.CreateAttendanceAsync(request);
        return Ok(response);
    }

    // GET: api/attendances
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var attendances = await service.GetAllAsync();
        return Ok(attendances);
    }

    // GET: api/attendances/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var attendance = await service.GetByIdAsync(id);
        if (attendance is null)
            return NotFound();
        return Ok(attendance);
    }

    // PUT: api/attendances/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id,[FromBody] UpdateAttendanceRequest request)
    {
        var response = await service.UpdateAttendanceAsync(id, request);
        return Ok(response);
    }
}