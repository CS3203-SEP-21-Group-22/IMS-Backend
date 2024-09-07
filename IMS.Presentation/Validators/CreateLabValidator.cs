﻿using FluentValidation;
using IMS.ApplicationCore.DTO;
using System.Text.RegularExpressions;

namespace IMS.Presentation.Validators
{
    public class CreateLabValidator : AbstractValidator<CreateLabDTO>
    {
        private readonly string textPattern = @"^.{2,20}$";
        private readonly string imageUrlPattern = @"^https?:\/\/.*\.(?:png|jpg|jpeg|webp)$";

        public CreateLabValidator()
        {
            // Validate labName
            RuleFor(x => x.labName)
                .NotEmpty().WithMessage("Lab Name is required.")
                .Matches(textPattern).WithMessage("Invalid Lab Name. Must be between 2 and 20 characters.");

            // Validate labCode
            RuleFor(x => x.labCode)
                .NotEmpty().WithMessage("Lab Code is required.")
                .Matches(textPattern).WithMessage("Invalid Lab Code. Must be between 2 and 20 characters.");

            // Validate imageURL (optional)
            RuleFor(x => x.imageURL)
                .Cascade(CascadeMode.Stop)
                .Must(x => string.IsNullOrEmpty(x) || Regex.IsMatch(x, imageUrlPattern))
                .WithMessage("Invalid Image URL. Must be a valid URL ending with png, jpg, jpeg, or webp.")
                .When(x => !string.IsNullOrEmpty(x.imageURL));
        }
    }
}
