using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Features.Tools.Images.Commands.CreateImage;
public class CreateImageCommand : IRequest<string>
{
    public IFormFile Image { get; set; }
}
