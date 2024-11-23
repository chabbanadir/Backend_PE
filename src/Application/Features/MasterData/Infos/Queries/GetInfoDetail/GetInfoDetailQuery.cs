using MediatR;


namespace Backend.Application.Features.MasterData.Infos.Queries.GetInfoDetail;

public class GetInfoDetailQuery : IRequest<InfoDetailVm>
{
    public string? Id { get; set; }
}
