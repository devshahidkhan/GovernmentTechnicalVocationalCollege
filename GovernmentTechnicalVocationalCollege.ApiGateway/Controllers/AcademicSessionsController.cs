using GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Requests;
using GovernmentTechnicalVocationalCollege.Application.Services.AcademicSessionService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GovernmentTechnicalVocationalCollege.ApiGateway.Controllers
{
    [Route("api/academic-sessions")]
    [ApiController]
    public class AcademicSessionsController(IAcademicSessionService service): ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateAcademicSessionRequest request)
        {
            var response =await service.CreateAcademicSessionAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var academicSessions = await service.GetAllAsync();
            return Ok(academicSessions);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var academicSession = await service.GetByIdAsync(id);

            if (academicSession is null)
                return NotFound();

            return Ok(academicSession);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id,UpdateAcademicSessionRequest request)
        {
            var updated = await service.UpdateAcademicSessionAsync(request, id);
            return Ok(updated);
        }
    }
}
