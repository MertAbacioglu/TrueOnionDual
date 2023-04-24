using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueOnion.APPLICATION.DTOs;

namespace TrueOnion.APPLICATION.Validators
{
    public class DepartmentUpdateDTOValidator : AbstractValidator<DepartmentUpdateDTO>
    {
        public DepartmentUpdateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .Must(x => x.All(char.IsLetter)).WithMessage("The '{PropertyName}' field must contain only letters.")
            ;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");



        }

    }
}
