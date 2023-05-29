
using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Features.MasterData.Harnessmakers.Commands.UpdateHarnessmaker;

public class UpdateHarnessmakerCommand : IRequest<RequestResponseMessage>, IMapFrom<Harnessmaker>
{

    public Guid Id { get; set; }


    public string? Name { get; set; }
    public string? Manufacturing_code { get; set; }
    public string? Bar_code { get; set; }
    public int Status { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<Harnessmaker, UpdateHarnessmakerCommand>().ReverseMap();
    }
}
