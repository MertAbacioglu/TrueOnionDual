using FluentValidation;
using TrueOnion.APPLICATION.DTOs;

namespace TrueOnion.APPLICATION.Validators
{
    public class DepartmentCreateDTOValidator : AbstractValidator<DepartmentCreateDTO>
    {
        public DepartmentCreateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .Must(x => x.All(char.IsLetter)).WithMessage("The '{PropertyName}' field must contain only letters.")
                .WithMessage("{PropertyName} must only contain letter");
        }
    }
}