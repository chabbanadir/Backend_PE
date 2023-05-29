using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.MasterData.Infos.Queries.GetInfosByOem;

public class InfosByOemDto : IMapFrom<Info>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}
