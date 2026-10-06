using GovernmentTechnicalVocationalCollege.Domain.Enums;

namespace GovernmentTechnicalVocationalCollege.Domain.Entities
{
    public class TrainingProgram
    {
        public Guid Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int DurationValue { get; set; }

        public DurationUnit DurationUnit { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } 

        public DateTime? UpdatedAt { get; set; }

        public ICollection<Admission> Admissions { get; set; } = new List<Admission>();
    }
}
