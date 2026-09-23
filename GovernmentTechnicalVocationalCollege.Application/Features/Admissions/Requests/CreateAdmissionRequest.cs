using GovernmentTechnicalVocationalCollege.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests
{
    public record CreateAdmissionRequest(
        string AdmissionNo,
        Guid StudentId,
        Guid ProgramId,
        Guid AcademicSessionId,
        DateTime ApplicationDate,
        DateTime? AdmissionDate,
        AdmissionStatus Status,
        string? Remarks
        );
}
