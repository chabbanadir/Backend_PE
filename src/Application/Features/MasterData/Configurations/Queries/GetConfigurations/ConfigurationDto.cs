using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Configurations.Queries.GetConfigurations;

public class ConfigurationDto : IMapFrom<Config>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }

    public double Length { get; set; }
    public int Position { get; set; }
    public Status Status { get; set; }
    public Orientation Orientation { get; set; }

    public virtual OemDto Oem { get; set; } = null!;
    public virtual PictureDto Picture { get; set; } = null!;
    public virtual NoteDto Note { get; set; } = null!;



    public void Mapping(Profile profile)
    {
        profile.CreateMap<Config, ConfigurationDto>()
            .ForMember(d => d.Status, opt => opt.MapFrom(s => (int)s.Status));
    }


}
