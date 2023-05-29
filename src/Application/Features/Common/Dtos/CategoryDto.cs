﻿using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.Common.Dtos;

public class CategoryDto : IMapFrom<Category>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public bool HasNote { get; set; }
    public bool HasCable { get; set; }
    public bool HasConfig { get; set; }

}