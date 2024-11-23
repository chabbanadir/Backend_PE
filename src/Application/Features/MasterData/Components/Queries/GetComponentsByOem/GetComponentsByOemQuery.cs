

using MediatR;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentsByOem;

public class GetComponentsByOemQuery : IRequest<List<ComponentsByOemVm>>
{
    public string? oemId { get; set; }

    public string? categoryId { get; set; }

    public string? cableId { get; set; }
}
