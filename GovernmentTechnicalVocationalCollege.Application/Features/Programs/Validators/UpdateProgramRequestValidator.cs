using FluentValidation;
using GovernmentTechnicalVocationalCollege.Application.Features.Programs.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovernmentTechnicalVocationalCollege.Application.Features.Programs.Validators
{
    public class UpdateProgramRequestValidator: AbstractValidator<UpdateProgramRequest>
    {
        public UpdateProgramRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("Program code is required.")
                .MaximumLength(30)
                .WithMessage("Program code cannot exceed 30 characters.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Program name is required.")
                .MaximumLength(150)
                .WithMessage("Program name cannot exceed 150 characters.");

            RuleFor(x => x.DurationValue)
                .GreaterThan(0)
                .WithMessage("Duration value must be greater than zero.");

            RuleFor(x => x.DurationUnit)
                .IsInEnum()
                .WithMessage("Duration unit must be a valid value.");

            RuleFor(x => x.Description)
                .MaximumLength(1000)
                .WithMessage("Description cannot exceed 1000 characters.");
        }
    }
}
