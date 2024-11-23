using Backend.Application.Common.Security;
using FluentValidation;

namespace Backend.Application.Features.MasterData.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.File).SetValidator(new FileValidator());


        RuleFor(v => v.Status)
            .InclusiveBetween(0, 1).WithMessage("{PropertyName} must be Active or Inactive.");

        RuleFor(e => e.Name)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
    }
}
