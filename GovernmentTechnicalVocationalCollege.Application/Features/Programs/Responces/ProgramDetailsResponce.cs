using GovernmentTechnicalVocationalCollege.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Programs.Responces
{
    public record ProgramDetailsResponce(
        Guid Id,
        string? Code,
        string? Name,
        int DurationValue,
        DurationUnit DurationUnit,
        string? Description,
        bool IsActive,
        DateTime CreatedAt,
        DateTime UpdatedAt
        );
}
