using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponents;


public class GetComponentsResponse : IMapFrom<Component>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid FK_OemId { get; set; }
    public Guid FK_CategoryId { get; set; }
    public Status Status { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Component, GetComponentsResponse>().ReverseMap();
    }

}
