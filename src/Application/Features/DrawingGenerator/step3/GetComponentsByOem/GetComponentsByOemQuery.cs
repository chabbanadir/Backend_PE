using Backend.Application.Features.DrawingGenerator.step3.GetComponentsByOem.Dto;
using MediatR;

namespace Backend.Application.Features.DrawingGenerator.step3.GetComponentsByOem;

public class GetComponentsByOemQuery:IRequest<List<ComponentsByOemVm>>
{
    public string? oemId { get; set; }

}
