using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.MasterData.Oems.Queries.GetOemDetail.Dtos;
using Backend.Domain.Entities.MasterData;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Features.MasterData.Components.Commands.UpdateComponentDetail;

public class UpdateComponentDetailCommand : IRequest<RequestResponseMessage>, IMapFrom<Component>
{
    public string Id { get; set; }

    public string? Rev { get; set; }
    public string? Description { get; set; }
    public double? Length { get; set; }
    public int Position { get; set; }
    public int Orientation { get; set; }

    public string? FK_ConfigId { get; set; }

    public Guid? FK_PictureId { get; set; }
    public IFormFile? File { get; set; }

    public List<CompParts> Parts { get; set; } = new List<CompParts>();

    public class CompParts : IMapFrom<ComponentPart>
    {
        /*        public Guid FK_ComponentId { get; set; }
                public Guid? FK_PartId { get; set; }*/
        public  ComponentDto Part { get; set; }
        /*public virtual Component Component { get; set; }
          public virtual Component Part { get; set; }*/
    }



    public void Mapping(Profile profile)
    {
        profile.CreateMap<Component,UpdateComponentDetailCommand>().ReverseMap();
    }

}
