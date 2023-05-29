using FluentValidation;


namespace Backend.Application.Features.MasterData.Components.Commands.UpdateComponent;

public class UpdateComponentCommandValidator : AbstractValidator<UpdateComponentCommand>
{
    public UpdateComponentCommandValidator()
    {

        RuleFor(v => v.ShowIn)
            .InclusiveBetween(0, 3).WithMessage("{PropertyName} must be Active or Inactive.");


        RuleFor(v => v.Status)
            .InclusiveBetween(0, 1).WithMessage("{PropertyName} must be Active or Inactive.");

        RuleFor(e => e.Name)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(e => e.FK_OemId).MustAsync(async (id, cancellation) =>
        {

            if (!ValidateGuid(id))
            {
                return false;
            }

            return true;
        })
          .WithMessage("The specified Id is not exists.");


        RuleFor(e => e.FK_CategoryId).MustAsync(async (id, cancellation) =>
        {

            if (!ValidateGuid(id))
            {
                return false;
            }

            return true;
        })
          .WithMessage("The specified Id is not exists.");    
        
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