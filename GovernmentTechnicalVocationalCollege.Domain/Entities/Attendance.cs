using GovernmentTechnicalVocationalCollege.Domain.Enums;

namespace GovernmentTechnicalVocationalCollege.Domain.Entities
{
    public class Attendance
    {
        public Guid Id { get; set; }

        // Relationships
        public Guid AdmissionId { get; set; }

        public Guid InstructingAssignmentId { get; set; }

        // Attendance information
        public DateOnly AttendanceDate { get; set; }

        public AttendanceStatus Status { get; set; }

        public string? Remarks { get; set; }

        // Audit fields
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public Admission Admission { get; set; } = null!;

        public InstructingAssignment InstructingAssignment { get; set; } = null!;
    }
}
