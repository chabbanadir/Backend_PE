﻿using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Features.MasterData.Cables.Commands.CreateCable;

public class CreateCableCommand : IRequest<RequestResponseMessage>, IMapFrom<Cable>
{
    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }
    public string? Description { get; set; }
    public string? FK_OemId { get; set; }
    public int Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Cable, CreateCableCommand>().ReverseMap();
    }

}
