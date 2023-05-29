using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Packagess.Commands.CreatePackage;

public class CreatePackageCommand : IRequest<RequestResponseMessage>, IMapFrom<Package>
{
    public string? Layer { get; set; }
    public string? PN { get; set; }
    public string? Qte { get; set; }
    public int Order { get; set; }
    public int Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Package, CreatePackageCommand>().ReverseMap();
    }
}
