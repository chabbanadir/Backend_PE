using Backend.Application.Features.MasterData.Infos.Queries.GetInfosByOem;
using MediatR;

namespace Backend.Application.Features.MasterData.Infos.Queries.GetInfosByOem;

public class GetInfosByOemQuery : IRequest<List<InfosByOemVm>>
{
    public string? oemId { get; set; }
}
