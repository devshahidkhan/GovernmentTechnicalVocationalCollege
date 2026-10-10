using GovernmentTechnicalVocationalCollege.Application.Services.NumberGenerationService.Interface;
using GovernmentTechnicalVocationalCollege.Domain.Entities;
using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GovernmentTechnicalVocationalCollege.Application.Services.NumberGenerationService.Implementation
{
    public class NumberGenerationService(ApplicationDbContext context):INumberGeneratorService
    {
        public async Task<string> GenerateRegistrationNoAsync(int year)
        {
            var number = await GetNextNumberAsync(
                "Registration",
                year);

            return $"GTVC/PRP-DIK/{year}/{number:D6}";
        }

        public async Task<string> GenerateAdmissionNoAsync(int year)
        {
            var number = await GetNextNumberAsync(
                "Admission",
                year);

            return $"ADM-{year}-{number:D6}";
        }

        public async Task<string> GenerateEmployeeNoAsync(int year)
        {
            var number = await GetNextNumberAsync("Instructor", year);

            return $"TCH-{year}-{number:D6}";
        }

        private async Task<int> GetNextNumberAsync(string sequenceType,int year)
        {
            await using var transaction = await context.Database.BeginTransactionAsync(IsolationLevel.Serializable);

            var sequence = await context.NumberSequences
                .SingleOrDefaultAsync(x =>
                    x.SequenceType == sequenceType &&
                    x.Year == year);

            int currentNumber;

            if (sequence is null)
            {
                sequence = new NumberSequence
                {
                    Id = Guid.NewGuid(),
                    SequenceType = sequenceType,
                    Year = year,
                    NextNumber = 2,
                    CreatedAt = DateTime.UtcNow
                };

                currentNumber = 1;

                await context.NumberSequences.AddAsync(sequence);
            }
            else
            {
                currentNumber = sequence.NextNumber;

                sequence.NextNumber++;
                sequence.UpdatedAt = DateTime.UtcNow;
            }

            await context.SaveChangesAsync();
            await transaction.CommitAsync();
            return currentNumber;
        }
    }
}
