using GovernmentTechnicalVocationalCollege.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }

        public string? RegistrationNo { get; set; }

        public string? FirstName { get; set; } 

        public string? LastName { get; set; }

        public string? FatherName { get; set; }

        public string? CNIC { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public Gender? Gender { get; set; }

        public string Phone { get; set; } = null!;

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? ProfilePhotoUrl { get; set; }

        public StudentStatus Status { get; set; } = StudentStatus.Active;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }

        public ICollection<Admission> Admissions { get; set; } = new List<Admission>();
    }
}
