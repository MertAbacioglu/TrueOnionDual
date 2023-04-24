using FluentValidation;
using TrueOnion.APPLICATION.DTOs;

namespace TrueOnion.APPLICATION.Validators
{
    public class UserCreateWithDepartmentDTOValidator : AbstractValidator<AddUserWithDepartmentDTO>
    {
        //department rules
        public UserCreateWithDepartmentDTOValidator()
        {
            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");
        }

    }
}
