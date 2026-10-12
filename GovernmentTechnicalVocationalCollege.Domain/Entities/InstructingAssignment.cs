namespace GovernmentTechnicalVocationalCollege.Domain.Entities
{
    public class InstructingAssignment
    {
        public Guid Id { get; set; }

        // Foreign keys
        public Guid InstructorId { get; set; }

        public Guid TrainingProgramId { get; set; }

        public Guid AcademicSessionId { get; set; }

        // Assignment information
        public DateOnly AssignedDate { get; set; }

        public bool IsActive { get; set; } = true;

        // Audit fields
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public Instructor Instructor { get; set; } = null!;

        public TrainingProgram TrainingProgram { get; set; } = null!;

        public AcademicSession AcademicSession { get; set; } = null!;
    }
}
