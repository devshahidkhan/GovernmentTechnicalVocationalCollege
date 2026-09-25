//using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests;
////using GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Interface;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace GovernmentTechnicalVocationalCollege.ApiGateway.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AdmissionsController(IAdmissionService service) : ControllerBase
//    {
//        [HttpPost("CreateAdmission")]
//        public async Task<IActionResult> CreateAdmission(CreateAdmissionRequest request)
//        {
//            var responce = await service.CreateAdmissionAsync(request);
//            return Ok(responce);
//        }
//    }
//}
