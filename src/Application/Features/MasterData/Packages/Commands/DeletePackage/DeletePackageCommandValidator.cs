using FluentValidation;

namespace Backend.Application.Features.MasterData.Packages.Commands.DeletePackage;

public class DeletePackageCommandValidator : AbstractValidator<DeletePackageCommand>
{
    public DeletePackageCommandValidator()
    {


        RuleFor(e => e.Id).NotNull().NotEmpty().MustAsync(async (id, cancellation) =>
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
