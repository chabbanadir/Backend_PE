using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Oems.Queries.GetOems;

public class GetOemsResponse : IMapFrom<Oem>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Status Status { get; set; }
}
