using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Harnessmakers.Commands.CreateHarnessmaker;

public class CreateHarnessmakerCommand : IRequest<RequestResponseMessage>, IMapFrom<Harnessmaker>
{
    public string? Name { get; set; }
    public string? Manufacturing_code { get; set; }
    public string? Bar_code { get; set; }
    public int Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Harnessmaker, CreateHarnessmakerCommand>().ReverseMap().
            ForMember(d => d.Status, opt => opt.MapFrom(s => (int)s.Status));
    }
}
