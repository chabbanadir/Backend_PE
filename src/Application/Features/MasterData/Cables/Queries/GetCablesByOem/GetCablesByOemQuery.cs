using MediatR;

namespace Backend.Application.Features.MasterData.Cables.Queries.GetCablesByOem;

public class GetCablesByOemQuery : IRequest<List<CablesByOemVm>>
{
    public string? oemId { get; set; }
}
