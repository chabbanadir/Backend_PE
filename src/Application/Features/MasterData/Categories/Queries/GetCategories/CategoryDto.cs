using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Categories.Queries.GetCategories;

public class CategoryDto : IMapFrom<Category>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Status Status { get; set; }

    public virtual PictureDto Picture { get; set; } = null!;



    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, CategoryDto>()
            .ForMember(d => d.Status, opt => opt.MapFrom(s => (int)s.Status));
    }


}
