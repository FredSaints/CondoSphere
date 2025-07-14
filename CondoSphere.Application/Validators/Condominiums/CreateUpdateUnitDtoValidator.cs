using CondoSphere.Core.DTOs.Condominiums;
using FluentValidation;

namespace CondoSphere.Application.Validators.Condominiums
{
    public class CreateUpdateUnitDtoValidator : AbstractValidator<CreateUpdateUnitDto>
    {
        public CreateUpdateUnitDtoValidator()
        {
            RuleFor(x => x.Identifier)
                .NotEmpty().WithMessage("Identifier is required.")
                .MaximumLength(100).WithMessage("Identifier cannot exceed 100 characters.");
        }
    }
}