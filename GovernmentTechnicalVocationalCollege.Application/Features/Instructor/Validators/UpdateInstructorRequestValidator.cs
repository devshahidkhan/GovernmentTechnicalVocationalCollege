using FluentValidation;
using GovernmentTechnicalVocationalCollege.Application.Features.Instructors.Requests;


namespace GovernmentTechnicalVocationalCollege.Application.Features.Instructor.Validators
{
    public class UpdateInstructorRequestValidator:AbstractValidator<UpdateInstructorRequest>
    {
        public UpdateInstructorRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.")
                .MaximumLength(100)
                .WithMessage("First name cannot exceed 100 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.")
                .MaximumLength(100)
                .WithMessage("Last name cannot exceed 100 characters.");

            RuleFor(x => x.FatherName)
                .NotEmpty()
                .WithMessage("Father name is required.")
                .MaximumLength(100)
                .WithMessage("Father name cannot exceed 100 characters.");

            RuleFor(x => x.CNIC)
                .NotEmpty()
                .WithMessage("CNIC is required.")
                .Matches(@"^\d{5}-?\d{7}-?\d{1}$")
                .WithMessage(
                    "CNIC must contain 13 digits, with or without hyphens.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .MaximumLength(20)
                .WithMessage("Phone number cannot exceed 20 characters.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .When(x => !string.IsNullOrWhiteSpace(x.Email))
                .WithMessage("Please provide a valid email address.")
                .MaximumLength(254)
                .WithMessage("Email cannot exceed 254 characters.");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address is required.")
                .MaximumLength(500)
                .WithMessage("Address cannot exceed 500 characters.");
        }
    }
}
