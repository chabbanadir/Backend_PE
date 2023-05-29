using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Infos.Queries.GetInfos;


public class GetInfosResponse : IMapFrom<Info>
{
    public Guid Id { get; set; }
    public string? BaseNumber { get; set; }
    public string? CustomerPN { get; set; }
    public string? ProjectNumber { get; set; }
    public int? ComponentCount { get; set; }
    public OemDto Oem { get; set; } = null!;
    public HarnessMakerDto HarnessMarker { get; set; } = null!;
    public ComponentDto Component { get; set; } = null!;
    public CableDto Cable { get; set; } = null!;
}
