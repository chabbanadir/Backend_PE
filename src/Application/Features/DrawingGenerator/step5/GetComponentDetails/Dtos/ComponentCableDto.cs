using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.DrawingGenerator.step5.GetComponentDetails.Dtos;

public class ComponentCableDto : IMapFrom<ComponentCable>
{
    public Guid FK_CableId { get; set; }
   // public CableDto Cable { get; set; }
}
