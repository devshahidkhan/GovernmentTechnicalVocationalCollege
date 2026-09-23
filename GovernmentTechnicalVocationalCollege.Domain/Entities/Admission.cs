
using GovernmentTechnicalVocationalCollege.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Domain.Entities
{
    public class Admission
    {
        public Guid Id { get; set; }

        // Unique business identifier
        public string AdmissionNo { get; set; } = null!;

        // Relationships
        public Guid StudentId { get; set; }
        public Guid TrainingProgramId { get; set; }
        public Guid AcademicSessionId { get; set; }

        // Admission lifecycle
        public DateOnly ApplicationDate { get; set; }
        public DateOnly? AdmissionDate { get; set; }

        public AdmissionStatus Status { get; set; }

        // Reason for rejection, cancellation, withdrawal, expulsion, etc.
        public string? StatusReason { get; set; }
        public string? Remarks { get; set; }

        // Audit
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        // Navigation properties

        public Student Student { get; set; } = null!;
        public TrainingProgram TrainingProgram { get; set; } = null!;
        public AcademicSession AcademicSession { get; set; } = null!;

        // Status change history
        //public ICollection<AdmissionStatusHistory> StatusHistory { get; set; }
        //    = new List<AdmissionStatusHistory>();
    }
}
