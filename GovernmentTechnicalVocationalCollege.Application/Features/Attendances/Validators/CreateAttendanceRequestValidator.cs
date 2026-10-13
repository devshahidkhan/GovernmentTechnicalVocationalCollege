using FluentValidation;
using GovernmentTechnicalVocationalCollege.Application.Features.Attendances.Requests;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Attendances.Validators;

public class CreateAttendanceRequestValidator: AbstractValidator<CreateAttendanceRequest>
{
    public CreateAttendanceRequestValidator()
    {
        RuleFor(x => x.AdmissionId)
            .NotEmpty()
            .WithMessage("Admission is required.");

        RuleFor(x => x.InstructingAssignmentId)
            .NotEmpty()
            .WithMessage("Teaching assignment is required.");

        RuleFor(x => x.AttendanceDate)
            .Must(date => date != default)
            .WithMessage("Attendance date is required.");

        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Invalid attendance status.");

        RuleFor(x => x.Remarks)
            .MaximumLength(500)
            .WithMessage("Remarks cannot exceed 500 characters.");
    }
}