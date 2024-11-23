using Backend.Application.Common.Security;
using FluentValidation;


namespace Backend.Application.Features.MasterData.Components.Commands.UpdateComponentDetail;

public class UpdateComponentDetailCommandValidator : AbstractValidator<UpdateComponentDetailCommand>
{
    public UpdateComponentDetailCommandValidator()
    {
        RuleFor(x => x.File).SetValidator(new FileValidator());

        RuleFor(e => e.Id).MustAsync(async (id, cancellation) =>
        {

            if (!ValidateGuid(id))
            {
                return false;
            }

            return true;
        })
          .WithMessage("The specified Id is not exists.");


    }

    private bool ValidateGuid(string id)
    {
        return Guid.TryParse(id, out var result);
    }
}