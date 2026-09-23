using GovernmentTechnicalVocationalCollege.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests
{
    public record CreateProgramRequest(
        string? Code,
        string? Name,
        int DurationValue,
        DurationUnit DurationUnit,
        string? Description,
        decimal Fee
        );
}
