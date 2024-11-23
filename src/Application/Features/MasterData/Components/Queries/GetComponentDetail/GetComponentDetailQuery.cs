using MediatR;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentDetail;

public class GetComponentDetailQuery : IRequest<ComponentDetailVm>
{
    public string? Id { get; set; }

}
