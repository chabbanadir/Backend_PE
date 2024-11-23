using FluentValidation;

namespace Backend.Application.Features.MasterData.Cables.Commands.CreateCable;

public class CreateCableCommandValidator : AbstractValidator<CreateCableCommand>
{

    public CreateCableCommandValidator()
    {

        RuleFor(e => e.FK_OemId).MustAsync(async (id, cancellation) =>
        {

            if (!ValidateGuid(id))
            {
                return false;
            }

            return true;
        })
       .WithMessage("The specified OemId is not exists.");





        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");


        RuleFor(v => v.Status)
            .InclusiveBetween(0, 1).WithMessage("{PropertyName} must be Active or Inactive.");

    }



    private bool ValidateGuid(string id)
    {
        return Guid.TryParse(id, out var result);
    }
}
