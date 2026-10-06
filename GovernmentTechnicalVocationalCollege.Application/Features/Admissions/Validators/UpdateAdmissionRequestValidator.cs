using FluentValidation;
using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests;
using GovernmentTechnicalVocationalCollege.Domain.Enums;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Validators
{
    public class UpdateAdmissionRequestValidator: AbstractValidator<UpdateAdmissionRequest>
    {
        public UpdateAdmissionRequestValidator()
        {
            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Invalid admission status.");

            RuleFor(x => x.AdmissionDate)
                .NotNull()
                .When(x =>
                    x.Status == AdmissionStatus.Approved ||
                    x.Status == AdmissionStatus.Active ||
                    x.Status == AdmissionStatus.Completed)
                .WithMessage(
                    "Admission date is required for approved, active or completed admissions.");

            RuleFor(x => x.StatusReason)
                .NotEmpty()
                .When(x =>
                    x.Status == AdmissionStatus.Rejected ||
                    x.Status == AdmissionStatus.Cancelled ||
                    x.Status == AdmissionStatus.Withdrawn ||
                    x.Status == AdmissionStatus.Expelled)
                .WithMessage(
                    "Status reason is required for this admission status.");

            RuleFor(x => x.StatusReason)
                .MaximumLength(500)
                .WithMessage(
                    "Status reason cannot exceed 500 characters.");

            RuleFor(x => x.Remarks)
                .MaximumLength(1000)
                .WithMessage(
                    "Remarks cannot exceed 1000 characters.");
        }
    }
}