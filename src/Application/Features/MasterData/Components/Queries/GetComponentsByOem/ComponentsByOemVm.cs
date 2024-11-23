using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentsByOem;

public class ComponentsByOemVm : IMapFrom<Component>
{
    public Guid Id { get; set; }
    public Guid categoryId { get; set; }
    public Guid cabletype { get; set; }
    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }

}

