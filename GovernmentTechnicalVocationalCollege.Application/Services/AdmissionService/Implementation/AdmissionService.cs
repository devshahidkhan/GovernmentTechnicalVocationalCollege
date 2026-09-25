//using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests;

//using GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Interface;
//using GovernmentTechnicalVocationalCollege.Domain.Repositories.AdmissionRepository.Interface;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Implementation
//{
//    public class AdmissionService(IAdmissionRepository repository) : IAdmissionService
//    {
//        public async Task<string> CreateAdmissionAsync(CreateAdmissionRequest request)
//        {
//            var Admission = request.MapToAdmissionEntity();
//            await repository.AddAdmissionsAsync(Admission);
//            return "Admission created successfully";
//        }
//    }
//}
