using GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests;
using GovernmentTechnicalVocationalCollege.Application.Mappers.StudentMappers;
using GovernmentTechnicalVocationalCollege.Application.Services.StudentService.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GovernmentTechnicalVocationalCollege.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(IStudentService service) : ControllerBase
    {
        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreateStudent(CreateStudentRequest request)
        {
            var isSaved = await service.CreateStudentAsync(request);
            return Ok(isSaved);
        }
    }
}
