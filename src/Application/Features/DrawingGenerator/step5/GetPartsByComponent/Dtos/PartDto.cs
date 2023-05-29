using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.DrawingGenerator.step5.GetPartsByComponent.Dtos;

public class PartDto : IMapFrom<ComponentPart>
{
    public Guid? FK_PartId { get; set; }
    public virtual ComponentDto Part { get; set; }
}
