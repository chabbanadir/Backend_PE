using Backend.Application.Features.MasterData.Infos.Queries.GetInfosByHarnessMaker;
using MediatR;

namespace Backend.Application.Features.MasterData.Infos.Queries.GetInfosByHarnessMaker;

public class GetInfosByHarnessMakerQuery : IRequest<List<InfosByHarnessMakerVm>>
{
    public string? HarnessMakerId { get; set; }
}
