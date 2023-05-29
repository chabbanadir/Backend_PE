using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Features.MasterData.Infos.Commands.CreateInfo;

public class CreateInfoCommand : IRequest<RequestResponseMessage>, IMapFrom<Info>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? CustomerPN { get; set; }
    public string? ProjectNumber { get; set; }
    public int? ComponentCount { get; set; }
    public string? FK_OemId { get; set; }
    public string? FK_HarnessMakerId { get; set; }
    public string? FK_ComponentId { get; set; }
    public string? FK_CableId { get; set; }
    //public int Status { get; set; }
    public IFormFile? File { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Info, CreateInfoCommand>().ReverseMap();
    }

}

