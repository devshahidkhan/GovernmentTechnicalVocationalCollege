//using GovernmentTechnicalVocationalCollege.Domain.Entities;
//using GovernmentTechnicalVocationalCollege.Domain.Repositories.AdmissionRepository.Interface;
//using GovernmentTechnicalVocationalCollege.Infrastructure.Data;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace GovernmentTechnicalVocationalCollege.Presentation.Persistence.AdmissionRepository.Implementation
//{
//    public class AdmissionRepository(ApplicationDbContext context) : IAdmissionRepository
//    {
//        public async Task AddAdmissionsAsync(Admission admission)
//        {
//             await context.Admissions.AddAsync(admission);
//             await context.SaveChangesAsync();
//        }
//    }
//}
