using GovernmentTechnicalVocationalCollege.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests
{
    public record UpdateAdmissionRequest(
        DateOnly? AdmissionDate,
        AdmissionStatus Status,
        string? StatusReason,
        string? Remarks
        );
}
