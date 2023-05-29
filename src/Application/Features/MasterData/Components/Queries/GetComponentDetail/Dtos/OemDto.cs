﻿using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentDetail.Dtos;

public class OemDto : IMapFrom<Oem>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}