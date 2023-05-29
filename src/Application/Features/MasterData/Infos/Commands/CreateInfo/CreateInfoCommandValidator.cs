using FluentValidation;
using Backend.Application.Common.Security;
namespace Backend.Application.Features.MasterData.Infos.Commands.CreateInfo;

public class CreateInfoCommandValidator : AbstractValidator<CreateInfoCommand>
{

    public CreateInfoCommandValidator()
    {
        RuleFor(x => x.File).SetValidator(new FileValidator());


        RuleFor(e => e.FK_OemId).MustAsync(async (id, cancellation) =>
        {

            if (!ValidateGuid(id))
            {
                return false;
            }

            return true;
        })
      .WithMessage("The specified OemId is not exists.");
        RuleFor(e => e.FK_HarnessMakerId ).MustAsync(async (id, cancellation) =>
        {

            if (!ValidateGuid(id))
            {
                return false;
            }

            return true;
        })

.WithMessage("The specified HarnessMakerId is not exists.");
        RuleFor(e => e.FK_ComponentId).MustAsync(async (id, cancellation) =>
        {

            if (!ValidateGuid(id))
            {
                return false;
            }

            return true;
        })

.WithMessage("The specified ComponentId is not exists.");

        RuleFor(e => e.FK_CableId).MustAsync(async (id, cancellation) =>
        {

            if (!ValidateGuid(id))
            {
                return false;
            }

            return true;
        })
.WithMessage("The specified CableId is not exists.");



        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



    }



    private bool ValidateGuid(string id)
    {
        return Guid.TryParse(id, out var result);
    }
}
