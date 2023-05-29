using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.MasterData.Oems.Queries.GetComponents;

public class ComponentsResponse : IMapFrom<Oem>
{
    public virtual ICollection<ComponentDto> Components { get; set; } = new HashSet<ComponentDto>();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Oem, ComponentsResponse>().ReverseMap();
    }
}

