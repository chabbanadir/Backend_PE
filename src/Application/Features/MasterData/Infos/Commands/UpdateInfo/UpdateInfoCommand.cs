using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Infos.Commands.UpdateInfo;

public class UpdateInfoCommand : IRequest<RequestResponseMessage>, IMapFrom<Info>
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? CustomerPN { get; set; }
    public string? ProjectNumber { get; set; }
    public int? ComponentCount { get; set; }
    public string? FK_OemId { get; set; }
    public string? FK_HarnessMakerId { get; set; }
    public string? FK_ComponentId { get; set; }
    public string? FK_CableId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Info, UpdateInfoCommand>().ReverseMap();
    }

}
