using FluentValidation;

namespace Backend.Application.Features.MasterData.Components.Commands.Parts.AddPart;
public class AddPartCommandValidator : AbstractValidator<AddPartCommand>
{
    public AddPartCommandValidator()
    {


        RuleFor(e => e.FK_ComponentId).MustAsync(async (id, cancellation) =>
        {

            if (!ValidateGuid(id))
            {
                return false;
            }

            return true;
        })
        .WithMessage("The specified Id is not exists.");
        
        
        RuleFor(e => e.FK_PartId).MustAsync(async (id, cancellation) =>
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
