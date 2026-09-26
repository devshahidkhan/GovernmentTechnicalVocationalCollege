using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Responses;
using GovernmentTechnicalVocationalCollege.Domain.Entities;


namespace GovernmentTechnicalVocationalCollege.Application.Mappers.ProgramMappers
{
    public static class ProgramMapper
    {
        public static TrainingProgram MapToEntity(this CreateProgramRequest request)
        {
            var now = DateTime.UtcNow;

            return new TrainingProgram
            {
                Id = Guid.NewGuid(),

                Code = request.Code,
                Name = request.Name,

                DurationValue = request.DurationValue,
                DurationUnit = request.DurationUnit,

                Description = request.Description,

                IsActive = true,

                CreatedAt = now,
                UpdatedAt = now
            };
        }

        public static void MapToEntity( this UpdateProgramRequest request, TrainingProgram program)
        {
            program.Code = request.Code;
            program.Name = request.Name;

            program.DurationValue = request.DurationValue;
            program.DurationUnit = request.DurationUnit;

            program.Description = request.Description;

            program.IsActive = request.IsActive;

            program.UpdatedAt = DateTime.UtcNow;
        }

        public static ProgramListResponse MapToListResponse(this TrainingProgram program)
        {
            return new ProgramListResponse(
                program.Id,
                program.Code,
                program.Name,
                program.DurationValue,
                program.DurationUnit,
                program.Description,
                program.IsActive
            );
        }

        public static ProgramDetailsResponse MapToDetailsResponse( this TrainingProgram program)
        {
            return new ProgramDetailsResponse(
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
