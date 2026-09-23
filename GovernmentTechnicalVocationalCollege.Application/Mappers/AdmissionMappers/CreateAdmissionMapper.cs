using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests;
using GovernmentTechnicalVocationalCollege.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Mappers.AdmissionMappers
{
    public static class CreateAdmissionMapper
    {
       public static Admission MapToAdmissionEntity(this CreateAdmissionRequest request)
        {
            return new Admission
            {
                AdmissionNo = request.AdmissionNo,
                StudentId = request.StudentId,
                ProgramId = request.ProgramId,
                AcademicSessionId = request.AcademicSessionId,
                ApplicationDate = request.ApplicationDate,
                AdmissionDate = request.AdmissionDate,
                Status = request.Status,
                Remarks = request.Remarks
            };
        }
    }
}
