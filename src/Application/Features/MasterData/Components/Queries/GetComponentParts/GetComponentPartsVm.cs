using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Application.Features.MasterData.Components.Queries.GetComponentParts.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentParts;

public class GetComponentPartsVm : IMapFrom<Component>
{
    public Guid Id { get; set; }

    public ICollection<PartDto> Parts { get; set; } = new HashSet<PartDto>();


    public void Mapping(Profile profile)
    {
        profile.CreateMap<Component, GetComponentPartsVm>().ReverseMap();
    }
}