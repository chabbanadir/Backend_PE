using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Features.MasterData.Configurations.Commands.UpdateConfiguration;

public class UpdateConfigurationCommand : IRequest<RequestResponseMessage>, IMapFrom<Config>
{

    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? Type { get; set; }

    public double Length { get; set; }
    public int Position { get; set; }
    public int Status { get; set; }
    public int Orientation { get; set; }

    public string? FK_OemId { get; set; }
    public string? FK_NoteId { get; set; }

    public IFormFile? File { get; set; }
    public Guid? FK_PictureId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Config, UpdateConfigurationCommand>().ReverseMap();
    }


}
