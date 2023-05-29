using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentDetail;

public class ComponentDetailVm : IMapFrom<Component>
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
    public OemDto Oem { get; set; }

    /* public OemDto Oem { get; set; } public PictureDto Picture { get; set; } */
    // public ConfigDto Config { get; set; }

    public List<CompParts> Parts { get; set; } = new List<CompParts>();
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Component, ComponentDetailVm>().ReverseMap()
            .ForMember(d => d.Status, opt => opt.MapFrom(s => (int)s.Status))
            .ForMember(d => d.ShowIn, opt => opt.MapFrom(s => (int)s.ShowIn));
    }


    public class CompParts : IMapFrom<ComponentPart>
    {
        public Guid Id { get; set; }
        public BrifComponent Part { get; set; }

    }

    public class BrifComponent : IMapFrom<Component>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? TE_PN { get; set; }
        public string? Customer_PN { get; set; }
    }


}
