using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Features.MasterData.Components.Commands.UpdateComponent;

public class UpdateComponentCommand : IRequest<RequestResponseMessage>, IMapFrom<Component>
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }
    public string? PDM_LINK_PN { get; set; }
    public int ShowIn { get; set; }
    public int Status { get; set; }

    public string? FK_OemId { get; set; }
    public string? FK_CategoryId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Component, UpdateComponentCommand>().ReverseMap();
    }

}
