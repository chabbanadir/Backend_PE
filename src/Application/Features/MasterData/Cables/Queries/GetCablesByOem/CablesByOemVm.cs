using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.MasterData.Cables.Queries.GetCablesByOem;

public class CablesByOemVm : IMapFrom<Cable>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}