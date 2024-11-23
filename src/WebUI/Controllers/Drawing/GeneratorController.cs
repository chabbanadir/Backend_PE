namespace Backend.WebUI.Controllers.Drawing;

using Backend.Application.Common.Exceptions;

using Backend.Application.Features.DrawingGenerator.step2.GetOemsHarnessMakers;
using Backend.Application.Features.DrawingGenerator.step3.GetComponentsByOem;
using Backend.Application.Features.DrawingGenerator.step4.GetCablesByOem;
using Backend.Application.Features.DrawingGenerator.step5.GetComponentDetails;
using Backend.Application.Features.DrawingGenerator.step5.GetPartsByComponent;
using Microsoft.AspNetCore.Mvc;

public class GeneratorController: DrawingControllerBase
{

/*    [HttpGet("oem/{id}")]
    public async Task<ActionResult<ComponentsResponse>> Get(string id)
    {
        return await Mediator.Send(new GetComponentsQuery { oemId = id });
    }*/

    //step2
    [HttpGet]
    public async Task<ActionResult<OemsHarnessMakersVm>> Get()
    {
        return await Mediator.Send(new GetOemsHarnessMakersQuery());
    }


    [HttpGet("oem/{id}/components")]
    public async Task<ActionResult<List<ComponentsByOemVm>>> Get(string id)
    {
        return await Mediator.Send(new GetComponentsByOemQuery { oemId = id });
    }    
    
    
    [HttpGet("oem/{id}/cables")]
    public async Task<ActionResult<List<CablesByOemVm>>> GetCables(string id)
    {
        return await Mediator.Send(new GetCablesByOemQuery { oemId = id });
    }


    [HttpGet("component/{id}/parts")]
    public async Task<ActionResult<ComponentDetailsVm>> GetParts(string id)
    {
        return await Mediator.Send(new GetComponentDetailsQuery { Id = id });
    }

}
