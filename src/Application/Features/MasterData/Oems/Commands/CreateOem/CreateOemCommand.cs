using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Oems.Commands.CreateOem;

public class CreateOemCommand : IRequest<RequestResponseMessage>, IMapFrom<Oem>
{
    public string Name { get; set; }
    public int Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Oem, CreateOemCommand>().ReverseMap();
    }
}
