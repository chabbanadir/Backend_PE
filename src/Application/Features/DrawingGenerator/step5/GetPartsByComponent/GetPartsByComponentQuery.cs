using MediatR;

namespace Backend.Application.Features.DrawingGenerator.step5.GetPartsByComponent;

public class GetPartsByComponentQuery : IRequest<PartsByComponentsVm>
{
    public string? Id { get; set; }
}
