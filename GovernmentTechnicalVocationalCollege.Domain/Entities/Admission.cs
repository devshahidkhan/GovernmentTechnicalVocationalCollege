using GovernmentTechnicalVocationalCollege.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Domain.Entities
{
    public class Admission
    {
        public Guid Id { get; set; }

        public string AdmissionNo { get; set; } = null!;

        // Foreign Keys
        public Guid StudentId { get; set; }
        public Guid ProgramId { get; set; }
        public Guid AcademicSessionId { get; set; }

        public DateTime ApplicationDate { get; set; }

        public DateTime? AdmissionDate { get; set; }

        public AdmissionStatus Status { get; set; }

        public string? Remarks { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation Properties
        public Student Student { get; set; } = null!;
        public Program Program { get; set; } = null!;
        public AcademicSession AcademicSession { get; set; } = null!;
    }
}
