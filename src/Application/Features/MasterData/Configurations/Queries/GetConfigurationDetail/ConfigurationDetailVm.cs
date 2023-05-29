using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Configurations.Queries.GetConfigurationDetail;

public class ConfigurationDetailVm : IMapFrom<Config>
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? Type { get; set; }

    public double Length { get; set; }
    public int Position { get; set; }
    public Status Status { get; set; }
    public Orientation Orientation { get; set; }

    public virtual PictureDto Picture { get; set; } = null!;
    public virtual OemDto Oem { get; set; } = null!;
    public virtual NoteDto Note { get; set; } = null!;
}
