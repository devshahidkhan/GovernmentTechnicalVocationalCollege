using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Requests
{
    public class CreateAcademicSessionRequest
    {
        public string Name { get; set; } = null!;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
