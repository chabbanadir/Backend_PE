using Backend.Application.Features.Tools.Images.Commands.CreateImage;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebUI.Controllers.Tools;


public class ImageController : ToolControllerBase
{

    [HttpPost("upload")]
    public async Task<ActionResult<String>> Create([FromForm] CreateImageCommand createImageCommand)
    {
        var id = await Mediator.Send(createImageCommand);
        return Ok(id);
    }

}
