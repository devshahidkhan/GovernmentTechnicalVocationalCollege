namespace GovernmentTechnicalVocationalCollege.Domain.Entities
{
    public class NumberSequence
    {
        public Guid Id { get; set; }

        public string SequenceType { get; set; } = string.Empty;

        public int Year { get; set; }

        public int NextNumber { get; set; } = 1;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
