using FluentValidation;
using GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests;


namespace GovernmentTechnicalVocationalCollege.Application.Features.Students.Validators
{
    public class CreateStudentRequestValidator:AbstractValidator<CreateStudentRequest>
    {
        public CreateStudentRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100).WithMessage("First name must not exceed 100 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100).WithMessage("Last name must not exceed 100 characters.");

            RuleFor(x => x.FatherName)
                .NotEmpty().WithMessage("Father name is required.")
                .MaximumLength(100).WithMessage("Father name must not exceed 100 characters.");

            RuleFor(x => x.CNIC)
                .NotEmpty().WithMessage("CNIC is required.")
                .MaximumLength(15).WithMessage("CNIC must not exceed 15 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(20).WithMessage("Phone number must not exceed 20 characters.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.");
        }
    }
}
