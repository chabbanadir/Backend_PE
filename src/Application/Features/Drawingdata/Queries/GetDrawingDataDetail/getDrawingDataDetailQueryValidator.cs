using FluentValidation;
using System;

namespace Backend.Application.Features.MasterData.Cables.Queries.GetCableDetail
{
    public class GetCableDetailQueryValidator : AbstractValidator<GetCableDetailQuery>
    {
        public GetCableDetailQueryValidator()
        {
            RuleFor(query => query.Id)
                .NotEmpty().WithMessage("Cable ID is required.")
                .Must(ValidateGuid).WithMessage("Invalid Cable ID format.");
        }

        private bool ValidateGuid(string id)
        {
            return Guid.TryParse(id, out _);
        }
    }
}
