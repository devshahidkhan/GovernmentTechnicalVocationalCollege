using GovernmentTechnicalVocationalCollege.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Domain.Entities
{
    public class TrainingProgram
    {
        public Guid Id { get; set; }

        public string? Code { get; set; } 

        public string? Name { get; set; }

        public int DurationValue { get; set; }

        public DurationUnit DurationUnit { get; set; }

        public string? Description { get; set; }

        //public decimal Fee { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Relationships
        public ICollection<Admission> Admissions { get; set; } = new List<Admission>();
    }
}
