using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests;
using GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GovernmentTechnicalVocationalCollege.ApiGateway.Controllers
{
    [Route("api/admissions")]
    [ApiController]
    public class AdmissionsController(IAdmissionService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAdmissionRequest request)
        {
            var response = await service.CreateAdmissionAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var admissions = await service.GetAllAsync();
            return Ok(admissions);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var admission = await service.GetByIdAsync(id);

            if (admission is null)
                return NotFound();

            return Ok(admission);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] UpdateAdmissionRequest request)
        {
            var updated = await service.UpdateAdmissionAsync(id, request);
            return Ok(updated);
        }
    }
}