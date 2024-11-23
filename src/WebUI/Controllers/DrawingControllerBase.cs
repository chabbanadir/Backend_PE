using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebUI.Controllers;

[ApiController]
[Route("api/drawing-generator/")]
public abstract class DrawingControllerBase : ControllerBase
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
