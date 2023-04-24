using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueOnion.APPLICATION.DTOs;

namespace TrueOnion.APPLICATION.Validators
{
    public class UserUpdateDTOValidator : AbstractValidator<UserUpdateDTO>
    {
        public UserUpdateDTOValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .Must(x => x.All(char.IsLetter))
                .WithMessage("{PropertyName} must only contain letter");


            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} is not valid");

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");
            
            //RuleFor(x => x.DepartmentId)
            //    .NotEmpty().WithMessage("{PropertyName} is required")
            //    .NotNull().WithMessage("{PropertyName} is required")
            //    .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0")
            //    .Must(x => int.TryParse(x.ToString(), out _)).WithMessage("{PropertyName} must be a number");





        }
    }
}
