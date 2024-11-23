using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Entities.Tools;

namespace Backend.Application.Features.DrawingGenerator.step5.GetComponentDetails.Dtos;

public class PartDto : IMapFrom<ComponentPart>
{
    public Guid? FK_PartId { get; set; }
  //  public virtual ComponentDto Part { get; set; }
}