using Backend.Application.Features.Drawings.Queries.GetDrawingDetail;
using MediatR;


namespace Backend.Application.Features.MasterData.Cables.Queries.GetCableDetail;

public class GetDrawingDataDetailQuery : IRequest<DrawingDataDetailVm>
{
    public string? Id { get; set; }
}
