using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Services.NumberGenerationService.Interface
{
     public interface INumberGeneratorService
     {
        Task<string> GenerateRegistrationNoAsync(int year);

        Task<string> GenerateAdmissionNoAsync(int year);

        Task<string> GenerateEmployeeNoAsync(int year);
    }
}
