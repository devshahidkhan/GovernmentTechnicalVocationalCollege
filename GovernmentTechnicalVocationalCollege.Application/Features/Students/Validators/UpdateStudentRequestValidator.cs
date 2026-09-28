using FluentValidation;
using GovernmentTechnicalVocationalCollege.Application.Features.Students.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Students.Validators
{
    public class UpdateStudentRequestValidator:AbstractValidator<UpdateStudentRequest>
    {
        public UpdateStudentRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100)
                .WithMessage("First name must not exceed 100 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100)
                .WithMessage("Last name must not exceed 100 characters.");

            RuleFor(x => x.FatherName)
                .NotEmpty().WithMessage("Father name is required.")
                .MaximumLength(100)
                .WithMessage("Father name must not exceed 100 characters.");

            RuleFor(x => x.CNIC)
                .NotEmpty().WithMessage("CNIC is required.")
                .Matches(@"^\d{5}-\d{7}-\d{1}$")
                .WithMessage("CNIC must be in the format 12345-1234567-1.");

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateOnly.FromDateTime(DateTime.Today))
                .When(x => x.DateOfBirth.HasValue)
                .WithMessage("Date of birth must be in the past.");

            RuleFor(x => x.Gender)
                .IsInEnum()
                .When(x => x.Gender.HasValue)
                .WithMessage("Invalid gender selected.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^03\d{9}$")
                .WithMessage("Phone number must be a valid 11-digit Pakistani mobile number.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .When(x => !string.IsNullOrWhiteSpace(x.Email))
                .WithMessage("Please enter a valid email address.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.");

            RuleFor(x => x.ProfilePhotoUrl)
                .MaximumLength(500)
                .When(x => !string.IsNullOrWhiteSpace(x.ProfilePhotoUrl))
                .WithMessage("Profile photo URL must not exceed 500 characters.");
        }
    }
}
