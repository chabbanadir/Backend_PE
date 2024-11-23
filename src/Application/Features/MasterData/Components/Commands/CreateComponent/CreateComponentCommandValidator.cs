using Backend.Application.Common.Security;
using FluentValidation;

namespace Backend.Application.Features.MasterData.Components.Commands.CreateComponent;

public class CreateComponentCommandValidator : AbstractValidator<CreateComponentCommand>
{
    public CreateComponentCommandValidator()
    {
        RuleFor(x => x.File).SetValidator(new FileValidator());


        RuleFor(e => e.Name)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(v => v.Status)
            .InclusiveBetween(0, 1).WithMessage("{PropertyName} must be Active or Inactive.");



        RuleFor(e => e.FK_OemId).MustAsync(async (id, cancellation) =>
        {

            if (!ValidateGuid(id))
            {
                return false;
            }

            return true;
        })
          .WithMessage("The specified OemId is not exists.");
    }

    private bool ValidateGuid(string id)
    {
        return Guid.TryParse(id, out var result);
    }
}