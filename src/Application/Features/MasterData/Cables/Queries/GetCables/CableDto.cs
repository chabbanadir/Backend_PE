﻿using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Cables.Queries.GetCables;

public class CableDto : IMapFrom<Cable>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }
    public string? Description { get; set; }
    public OemDto Oem { get; set; } = null!;

    public Status Status { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<Cable, CableDto>()
            .ForMember(d => d.Status, opt => opt.MapFrom(s => (int)s.Status));
    }


}