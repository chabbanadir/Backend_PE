using FluentValidation;


namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentParts;


public class GetComponentPartsValidator : AbstractValidator<GetComponentPartsQuery>
{

    public GetComponentPartsValidator()
    {

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
