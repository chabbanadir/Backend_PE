using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Oems.Queries.GetOemDetail.Dtos;

public class PartDto : IMapFrom<ComponentPart>
{
    public virtual ComponentDto Part { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ComponentPart, PartDto>().ReverseMap();
    }

}