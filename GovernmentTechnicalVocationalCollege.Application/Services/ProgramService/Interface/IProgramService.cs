using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Services.ProgramService.Interface
{
    public interface IProgramService
    {
        Task<string> CreateProgramAsync(CreateProgramRequest request);
    }
}
