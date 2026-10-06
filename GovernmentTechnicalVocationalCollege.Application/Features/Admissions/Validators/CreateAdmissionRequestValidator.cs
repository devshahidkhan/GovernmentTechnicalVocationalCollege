using FluentValidation;
using GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Requests;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Admissions.Validators
{
    public class CreateAdmissionRequestValidator:AbstractValidator<CreateAdmissionRequest>
    {
        public CreateAdmissionRequestValidator()
        {
            RuleFor(x => x.StudentId)
                .NotEmpty()
                .WithMessage("Student is required.");

            RuleFor(x => x.TrainingProgramId)
                .NotEmpty()
                .WithMessage("Training program is required.");

            RuleFor(x => x.AcademicSessionId)
                .NotEmpty()
                .WithMessage("Academic session is required.");

            RuleFor(x => x.ApplicationDate)
                .NotEmpty()
                .WithMessage("Application date is required.");

            RuleFor(x => x.Remarks)
                .MaximumLength(1000)
                .WithMessage("Remarks cannot exceed 1000 characters.");
        }
    }
}
