using Backend.Application.Common.Security;
using FluentValidation;

namespace Backend.Application.Features.Tools.Images.Commands.CreateImage;

public class CreateImageCommandValidator : AbstractValidator<CreateImageCommand>
{

    public CreateImageCommandValidator()
    {
        RuleFor(x => x.Image).SetValidator(new FileValidator());
    }
}
