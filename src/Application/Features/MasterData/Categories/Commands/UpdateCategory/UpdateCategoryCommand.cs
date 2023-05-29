
using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Features.MasterData.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<RequestResponseMessage>, IMapFrom<Category>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool HasNote { get; set; }
    public bool HasCable { get; set; }
    public bool HasConfig { get; set; }
    public int Status { get; set; }
    public IFormFile File { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
    }

}
