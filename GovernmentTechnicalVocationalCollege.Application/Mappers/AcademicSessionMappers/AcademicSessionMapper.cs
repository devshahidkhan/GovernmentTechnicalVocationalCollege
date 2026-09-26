using GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Requests;
using GovernmentTechnicalVocationalCollege.Application.Features.AcademicSessions.Responces;
using GovernmentTechnicalVocationalCollege.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Mappers.AcademicSessionMappers
{
    public static class AcademicSessionMapper
    {
        public static AcademicSession MapToEntity(this CreateAcademicSessionRequest request)
        {
            var now = DateTime.UtcNow;
            return new AcademicSession
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                IsActive = true,
                CreatedAt = now,
                UpdatedAt = now
            };
        }

        public static AcademicSessionListResponse MapToListResponse(this AcademicSession session)
        {
            return new AcademicSessionListResponse(
                session.Id,
                session.Name,
                session.StartDate,
                session.EndDate,
                session.IsActive
            );
        }

        public static AcademicSessionDetailsResponse MapToDetailsResponse(this AcademicSession session)
        {
            return new AcademicSessionDetailsResponse(
                session.Id,
                session.Name,
                session.StartDate,
                session.EndDate,
                session.IsActive,
                session.CreatedAt,
                session.UpdatedAt
            );
        }

        public static void MapToEntity(this UpdateAcademicSessionRequest request, AcademicSession session)
        {
            session.Name = request.Name;
            session.StartDate = request.StartDate;
            session.EndDate = request.EndDate;
            session.IsActive = request.IsActive;
            session.UpdatedAt = DateTime.UtcNow;
        }
    }
}
