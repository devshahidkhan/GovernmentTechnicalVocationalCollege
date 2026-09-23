using GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Services.AcademicSessionService.Interface
{
    public interface IAcademicSessionService
    {
        Task<string> CreateAcademicSessionAsync(CreateAcademicSessionRequest request);
    }
}
