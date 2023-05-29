

using FluentValidation;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentsByOem;

public class GetComponentsByOemQueryValidator : AbstractValidator<GetComponentsByOemQuery>
{
    public GetComponentsByOemQueryValidator()
    {

        RuleFor(e => e.oemId).MustAsync(async (id, cancellation) =>
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