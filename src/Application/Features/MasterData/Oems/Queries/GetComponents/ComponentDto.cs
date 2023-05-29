using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.MasterData.Oems.Queries.GetComponents;

public class ComponentDto : IMapFrom<Component>
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }
    public string? PDM_LINK_PN { get; set; }
    public virtual ConfigDto Config { get; set; } = null!;
    public virtual PictureDto Picture { get; set; } = null!;
}
