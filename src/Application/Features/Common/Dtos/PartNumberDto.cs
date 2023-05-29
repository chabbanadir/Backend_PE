
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.DrawingGenerator;

namespace Backend.Application.Features.Common.Dtos;

public class PartNumberDto : IMapFrom<PartNumber>
{
    public Guid Id { get; set; }

    public string? BaseNumber { get; set; }
}
