using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Commands.Cables.AddCable;

public class AddCableCommand : IRequest<RequestResponseMessage>, IMapFrom<ComponentCable>
{
    public string? FK_ComponentId { get; set; }
    public string? FK_CableId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ComponentCable, AddCableCommand>().ReverseMap();
    }
}