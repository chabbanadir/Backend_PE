using Backend.Application.Common.Security;
using FluentValidation;

namespace Backend.Application.Features.MasterData.Notes.Commands.UpdateNote;

public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
{
    public UpdateNoteCommandValidator()
    {

        RuleFor(v => v.Status)
            .InclusiveBetween(0, 1).WithMessage("{PropertyName} must be Active or Inactive.");

    }
}
