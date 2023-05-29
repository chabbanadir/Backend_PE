using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentParts.Dtos;

public class PartDto : IMapFrom<ComponentPart>
{
    public Guid Id { get; set; }
    public Guid? FK_PartId { get; set; }
    public Guid FK_ComponentId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ComponentPart, PartDto>().ReverseMap();
    }
}
