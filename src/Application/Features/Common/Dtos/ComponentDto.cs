using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.Common.Dtos;

public class ComponentDto : IMapFrom<Component>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }
    public string? PDM_LINK_PN { get; set; }
    public string? Rev { get; set; }
    public string? Description { get; set; }
    public string? Length { get; set; }
}
