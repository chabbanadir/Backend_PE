using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.Common.Dtos;

public class ConfigDto : IMapFrom<Config>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public double Length { get; set; }
    public int Position { get; set; }
    public Status Status { get; set; }
    public Orientation Orientation { get; set; }
    public PictureDto Picture { get; set; }
    public NoteDto Note { get; set; }

}
