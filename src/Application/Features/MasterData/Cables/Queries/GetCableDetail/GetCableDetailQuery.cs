using MediatR;


namespace Backend.Application.Features.MasterData.Cables.Queries.GetCableDetail;

public class GetCableDetailQuery : IRequest<CableDetailVm>
{
    public string? Id { get; set; }
}
