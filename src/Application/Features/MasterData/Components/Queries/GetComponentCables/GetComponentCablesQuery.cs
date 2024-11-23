using MediatR;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentCables;

public class GetComponentCablesQuery : IRequest<GetComponentCablesVm>
{
    public string? Id { get; set; }

}
