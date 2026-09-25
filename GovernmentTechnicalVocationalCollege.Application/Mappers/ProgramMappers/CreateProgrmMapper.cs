using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using GovernmentTechnicalVocationalCollege.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Mappers.ProgramMappers
{
    public static class CreateProgrmMapper
    {
        public static TrainingProgram MapToEntity(this CreateProgramRequest request)
        {
            return new TrainingProgram
            {
                Id = Guid.NewGuid(),
                Code = request.Code,
                Name = request.Name,
                DurationValue = request.DurationValue,
                DurationUnit = request.DurationUnit,
                Description = request.Description,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
