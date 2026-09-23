using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Services.AdmissionService.Interface
{
    public interface IAdmissionService
    {
        Task<string> CreateAdmissionAsync(CreateAdmissionRequest request);
    }
}
