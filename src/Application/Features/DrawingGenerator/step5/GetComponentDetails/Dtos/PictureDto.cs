using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.Tools;

namespace Backend.Application.Features.DrawingGenerator.step5.GetComponentDetails.Dtos;

public class PictureDto : IMapFrom<Picture>
{
    public Guid Id { get; set; }
    public string? PicPath { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Picture, PictureDto>().ReverseMap();
    }
}