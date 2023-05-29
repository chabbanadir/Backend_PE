using FluentValidation;

namespace Backend.Application.Features.MasterData.Harnessmakers.Commands.UpdateHarnessmaker;

public class UpdateHarnessmakerCommandValidator : AbstractValidator<UpdateHarnessmakerCommand>
{
    public UpdateHarnessmakerCommandValidator()
    {

        RuleFor(v => v.Status)
            .InclusiveBetween(0, 1).WithMessage("{PropertyName} must be Active or Inactive.");

        RuleFor(e => e.Name)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
    }
}