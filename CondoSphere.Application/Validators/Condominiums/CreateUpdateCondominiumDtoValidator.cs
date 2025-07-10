using CondoSphere.Core.DTOs.Condominiums;
using FluentValidation;

namespace CondoSphere.Application.Validators.Condominiums
{
    public class CreateUpdateCondominiumDtoValidator : AbstractValidator<CreateUpdateCondominiumDto>
    {
        public CreateUpdateCondominiumDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(5, 255).WithMessage("Address must be between 5 and 255 characters.");
        }
    }
}