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

        public string RegistrationNo { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FatherName { get; set; } = string.Empty;

        public string CNIC { get; set; } = string.Empty;

        public DateOnly? DateOfBirth { get; set; } 

        public Gender? Gender { get; set; } 

        public string Phone { get; set; } = string.Empty;

        public string? Email { get; set; } 
        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string? ProfilePhotoUrl { get; set; }

        public StudentStatus Status { get; set; } = StudentStatus.Active;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Admission> Admissions { get; set; } = new List<Admission>();
    }
}
