using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueOnion.APPLICATION.DTOs;

namespace TrueOnion.APPLICATION.Validators
{
    public class UserCreateDTOValidator : AbstractValidator<UserCreateDTO>
    {
        public UserCreateDTOValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .Must(x => x.All(char.IsLetter)).WithMessage("The '{PropertyName}' field must contain only letters.")
                .WithMessage("{PropertyName} must only contain letter");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .Must(x => x.All(char.IsLetter)).WithMessage("The '{PropertyName}' field must contain only letters.")
                .WithMessage("{PropertyName} must only contain letter");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} is not valid");

        }
    }
}