using MediatR;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentParts;

public class GetComponentPartsQuery : IRequest<GetComponentPartsVm>
{
    public string? Id { get; set; }

}
