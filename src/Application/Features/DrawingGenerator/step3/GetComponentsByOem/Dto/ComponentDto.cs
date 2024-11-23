using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.DrawingGenerator.step3.GetComponentsByOem.Dto;

public class ComponentDto : IMapFrom<Component>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }
    public ConfigDto Config { get; set; } = null!;
    public PictureDto Picture { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Component, ComponentDto>().ReverseMap();
    }

}
