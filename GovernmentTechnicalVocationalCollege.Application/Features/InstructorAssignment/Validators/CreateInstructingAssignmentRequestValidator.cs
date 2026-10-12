using FluentValidation;
using GovernmentTechnicalVocationalCollege.Application.Features.InstructorAssignment.Requests;

namespace GovernmentTechnicalVocationalCollege.Application.Features.InstructorAssignment.Validators
{
    public class CreateInstructingAssignmentRequestValidator:AbstractValidator<CreateInstructingAssignmentRequest>
    {
        public CreateInstructingAssignmentRequestValidator()
        {
            RuleFor(x => x.InstructorId)
                .NotEmpty()
                .WithMessage("Teacher is required.");

            RuleFor(x => x.TrainingProgramId)
                .NotEmpty()
                .WithMessage("Training program is required.");

            RuleFor(x => x.AcademicSessionId)
                .NotEmpty()
                .WithMessage("Academic session is required.");

            RuleFor(x => x.AssignedDate)
                .Must(date => date != default)
                .WithMessage("Assignment date is required.");
        }
    }
}
