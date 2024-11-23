using FluentValidation;

namespace Backend.Application.Features.MasterData.Harnessmakers.Commands.CreateHarnessmaker;

public class CreateHarnessmakerCommandValidator : AbstractValidator<CreateHarnessmakerCommand>
{
    public CreateHarnessmakerCommandValidator()
    {
        RuleFor(v => v.Status)
       .InclusiveBetween(0, 1).WithMessage("{PropertyName} must be Active or Inactive.");
    }
}
