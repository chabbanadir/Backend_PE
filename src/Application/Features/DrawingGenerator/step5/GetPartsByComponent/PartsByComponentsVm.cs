using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Application.Features.DrawingGenerator.step5.GetPartsByComponent.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.DrawingGenerator.step5.GetPartsByComponent;

public class PartsByComponentsVm : IMapFrom<Component>
{

    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }
    public string? PDM_LINK_PN { get; set; }
    public string? Rev { get; set; }
    public string? Description { get; set; }
    public double Length { get; set; }
    public int Position { get; set; }


    public Guid FK_OemId { get; set; }
    public Guid FK_CategoryId { get; set; }
    public Guid? FK_ConfigId { get; set; }
    public Guid? FK_CableId { get; set; }
    public PictureDto Picture { get; set; }
    public Orientation Orientation { get; set; }

    public ShowIn ShowIn { get; set; }
    public Status Status { get; set; }

    public CategoryDto Category { get; set; }
    public ConfigDto Config { get; set; }
    public ICollection<CableDto> Cables { get; set; } = new HashSet<CableDto>();
    public ICollection<PartDto> Parts { get; set; } = new HashSet<PartDto>();


    public void Mapping(Profile profile)
    {
        profile.CreateMap<Component, PartsByComponentsVm>().ReverseMap()
            .ForMember(d => d.Status, opt => opt.MapFrom(s => (int)s.Status))
            .ForMember(d => d.ShowIn, opt => opt.MapFrom(s => (int)s.ShowIn));
    }
}
