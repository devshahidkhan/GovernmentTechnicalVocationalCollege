using GovernmentTechnicalVocationalCollege.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Domain.Repositories.AdmissionRepository.Interface
{
    public interface IAdmissionRepository
    {
        Task AddAdmissionsAsync(Admission admission);
    }
}
