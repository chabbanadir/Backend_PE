using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.MasterData.Components.Queries.GetComponentCables.Dtos;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentCables;

public class GetComponentCablesVm : IMapFrom<Component>
{
    public Guid Id { get; set; }

    public ICollection<CableDto> Cables { get; set; } = new HashSet<CableDto>();


    public void Mapping(Profile profile)
    {
        profile.CreateMap<Component, GetComponentCablesVm>().ReverseMap();
    }
}