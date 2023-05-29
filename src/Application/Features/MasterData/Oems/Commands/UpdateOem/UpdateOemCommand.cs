using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Oems.Commands.UpdateOem;

public class UpdateOemCommand : IRequest<RequestResponseMessage>, IMapFrom<Oem>
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int Status { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<Oem, UpdateOemCommand>().ReverseMap();
    }

}
