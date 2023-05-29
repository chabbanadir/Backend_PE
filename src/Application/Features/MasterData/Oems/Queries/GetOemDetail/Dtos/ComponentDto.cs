using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Oems.Queries.GetOemDetail.Dtos;

public class ComponentDto : IMapFrom<Component>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }

    public Guid FK_CategoryId { get; set; }
    public Guid? FK_ConfigId { get; set; }
    public Guid? FK_PictureId { get; set; }
    public Guid? FK_CableId { get; set; }

    public virtual List<ComponentPart> Parts { get; set; }

}

