using FluentValidation;

namespace Backend.Application.Features.MasterData.Harnessmakers.Queries.GetHarnessMakerDetail;

public class HarnessMakersDetailQueryValidator : AbstractValidator<HarnessMakersDetailQuery>
{
    public HarnessMakersDetailQueryValidator()
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
