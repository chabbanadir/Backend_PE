using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.Common.Dtos;

public class OemDto : IMapFrom<Oem>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}
