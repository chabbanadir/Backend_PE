using FluentValidation;


namespace Backend.Application.Features.DrawingGenerator.step4.GetCablesByOem;

public class GetCablesByOemQueryValidator : AbstractValidator<GetCablesByOemQuery>
{

    public GetCablesByOemQueryValidator()
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
