using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Responces;
using GovernmentTechnicalVocationalCollege.Domain.Entities;


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

        public static TrainingProgram MapToEntity(this UpdateProgramRequest request, TrainingProgram program)
        {
            program.Code = request.Code;
            program.Name = request.Name;
            program.DurationValue = request.DurationValue;
            program.DurationUnit = request.DurationUnit;
            program.Description = request.Description;
            program.IsActive = request.IsActive;
            program.UpdatedAt = DateTime.UtcNow;
            return program;
        }

        public static ProgramListResponce MapToListResponce(this TrainingProgram program)
        {
            return new ProgramListResponce(
                program.Id,
                program.Code,
                program.Name,
                program.DurationValue,
                program.DurationUnit,
                program.Description,
                program.IsActive
            );
        }

        public static ProgramDetailsResponce MapToDetailsResponce(this TrainingProgram program)
        {
            return new ProgramDetailsResponce(
                program.Id,
                program.Code,
                program.Name,
                program.DurationValue,
                program.DurationUnit,
                program.Description,
                program.IsActive,
                program.CreatedAt,
                program.UpdatedAt
            );
        }
    }
}
