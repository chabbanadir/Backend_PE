﻿using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Categories.Queries.GetCategories;


public class GetCategoriesResponse : IMapFrom<Category>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Status Status { get; set; }
    public bool HasNote { get; set; }
    public bool HasCable { get; set; }
    public bool HasConfig { get; set; }
    public virtual PictureDto Picture { get; set; } = null!;

}