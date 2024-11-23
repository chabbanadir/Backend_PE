using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Cables.Queries.GetCables;


public class GetCablesResponse : IMapFrom<Cable>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }
    public string? Description { get; set; }
    public virtual OemDto Oem { get; set; } = null!;
    public Status Status { get; set; }
}
