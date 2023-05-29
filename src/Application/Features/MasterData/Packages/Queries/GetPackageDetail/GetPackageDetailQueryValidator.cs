using FluentValidation;
namespace Backend.Application.Features.MasterData.Packages.Queries.GetPackageDetail;


public class GetPackageDetailQueryValidator : AbstractValidator<GetPackageDetailQuery>
{

    public GetPackageDetailQueryValidator()
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
