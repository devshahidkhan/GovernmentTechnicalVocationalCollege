using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Domain.Entities
{
    public class AcademicSession
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Admission> Admissions { get; set; } = new List<Admission>();
    }
}
