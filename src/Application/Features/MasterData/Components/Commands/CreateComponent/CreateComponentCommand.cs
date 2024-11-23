using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;
using Microsoft.AspNetCore.Http;
namespace Backend.Application.Features.MasterData.Components.Commands.CreateComponent;

public class CreateComponentCommand : IRequest<RequestResponseMessage>, IMapFrom<Component>
{
    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }
    public string? PDM_LINK_PN { get; set; }
    public string? Rev { get; set; }
    public string? Description { get; set; }

    public double Length { get; set; }
    public int Position { get; set; }

    public int ShowIn { get; set; }
    public int Status { get; set; }
    public int Orientation { get; set; }



    public string? FK_OemId { get; set; }
    public string? FK_CategoryId { get; set; }
    public string? FK_ConfigId { get; set; }
    public string? FK_CableId { get; set; }
    public string? FK_ParentComponentId { get; set; }
    public Guid? FK_PictureId { get; set; }

    public IFormFile File { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Component,CreateComponentCommand>().ReverseMap();
    }

}
