using Backend.Application.Features.DrawingData.Dtos;
using FluentValidation;

namespace Backend.Application.Features.DrawingData.Commands
{
    public class SaveDrawingDataCommandValidator : AbstractValidator<SaveDrawingDataCommand>
    {
        public SaveDrawingDataCommandValidator()
        {
            RuleFor(c => c.TEPartNumber).NotEmpty().WithMessage("TE Part Number is required.");
            RuleFor(c => c.CustomerPN).NotEmpty().WithMessage("Customer PN is required.");
            RuleFor(c => c.ProjectNumber).NotEmpty().WithMessage("Project Number is required.");
            RuleFor(c => c.OEM).NotEmpty().WithMessage("OEM is required.");
            RuleFor(c => c.HarnessMaker).NotEmpty().WithMessage("Harness Maker is required.");
            RuleFor(c => c.NumberOfConnectors).GreaterThan(0).WithMessage("Number of Connectors must be greater than zero.");
            RuleForEach(c => c.Components).SetValidator(new ComponentWithSideDtoValidator());
        }
    }

    public class ComponentWithSideDtoValidator : AbstractValidator<ComponentWithSideDto>
    {
        public ComponentWithSideDtoValidator()
        {
            RuleFor(c => c.Component).NotNull().WithMessage("Component is required.");
            RuleFor(c => c.Side).IsInEnum().WithMessage("Invalid Side value.");
        }
    }
}
