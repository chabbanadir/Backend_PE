using FluentValidation;

namespace Backend.Application.Features.MasterData.Oems.Commands.CreateOem;

public class CreateOemCommandValidator : AbstractValidator<CreateOemCommand>
{
    public CreateOemCommandValidator()
    {
        RuleFor(e => e.Name)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(v => v.Status)
       .InclusiveBetween(0, 1).WithMessage("{PropertyName} must be Active or Inactive.");
    }
}
