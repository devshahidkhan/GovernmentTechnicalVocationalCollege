using GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Requests;
using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Domain.Repositories.AcademicSessionRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Services.AcademicSessionService.Implementation
{
    public class AcademicSessionService(IAcademicSessionRepository repository)
    {
        
        private AcademicSession MapToEntity(CreateAcademicSessionRequest request)
        {
            return new AcademicSession{
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };
        }
    }
}
