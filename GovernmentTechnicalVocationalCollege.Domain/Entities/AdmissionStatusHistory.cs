using GovernmentTechnicalVocationalCollege.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Domain.Entities
{
    public class AdmissionStatusHistory
    {
        public int Guid { get; set; }

        public int AdmissionId { get; set; }

        public AdmissionStatus? FromStatus { get; set; }

        public AdmissionStatus ToStatus { get; set; }

        public string? Reason { get; set; }

        public DateTime ChangedAt { get; set; }

        public int? ChangedByUserId { get; set; }

        public Admission Admission { get; set; } = null!;

        //public User? ChangedByUser { get; set; }
    }
}
