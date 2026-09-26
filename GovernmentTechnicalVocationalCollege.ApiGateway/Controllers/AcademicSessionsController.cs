using GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using GovernmentTechnicalVocationalCollege.Application.Services.AcademicSessionService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GovernmentTechnicalVocationalCollege.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicSessionsController(IAcademicSessionService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAcademicSessionRequest request)
        {
            var response = await service.CreateAcademicSessionAsync(request);
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
        public IActionResult Update(UpdateAcademicSessionRequest request, Guid id)
        {
            var update = service.UpdateAcademicSessionAsync(request, id);

            return Ok(new
            {
                message = update
            });
        }
    }
}
