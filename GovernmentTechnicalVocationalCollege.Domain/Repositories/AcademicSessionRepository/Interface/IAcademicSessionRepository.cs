using GovernmentTechnicalVocationalCollege.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Domain.Repositories.AcademicSessionRepository.Interface
{
    public interface IAcademicSessionRepository
    {
        Task AddAcademicSessionAsync(AcademicSession session);
    }
}
