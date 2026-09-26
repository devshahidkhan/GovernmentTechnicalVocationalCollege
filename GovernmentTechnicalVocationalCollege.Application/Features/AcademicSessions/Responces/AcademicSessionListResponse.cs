using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Responces
{
    public record AcademicSessionListResponse(
        Guid Id,
        string Name,
        DateOnly StartDate,
        DateOnly EndDate,
        bool IsActive
        );
}
