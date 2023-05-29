using System;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.DrawingGenerator.step2.GetOemsHarnessMakers.Dto;

public class OemDto : IMapFrom<Oem>
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
}
