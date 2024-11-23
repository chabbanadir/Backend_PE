using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentCables.Dtos;

public class CableDto : IMapFrom<ComponentCable>
{
    public Guid Id { get; set; }
    public Guid FK_ComponentId { get; set; }
    public Guid? FK_CableId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ComponentCable, CableDto>().ReverseMap();
    }
}
