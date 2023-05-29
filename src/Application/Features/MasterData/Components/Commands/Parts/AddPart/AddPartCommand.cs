using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Commands.Parts.AddPart;

public class AddPartCommand : IRequest<RequestResponseMessage>, IMapFrom<ComponentPart>
{
    public string? FK_ComponentId { get; set; }
    public string? FK_PartId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ComponentPart, AddPartCommand>().ReverseMap();
    }
}