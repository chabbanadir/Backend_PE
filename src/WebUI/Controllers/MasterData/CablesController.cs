using Backend.Application.Common.Exceptions;
using Backend.Application.Features.MasterData.Cables.Commands.CreateCable;
using Backend.Application.Features.MasterData.Cables.Commands.DeleteCable;
using Backend.Application.Features.MasterData.Cables.Commands.UpdateCable;
using Backend.Application.Features.MasterData.Cables.Queries.GetCableDetail;
using Backend.Application.Features.MasterData.Cables.Queries.GetCables;
using Backend.Application.Features.MasterData.Cables.Queries.GetCablesByOem;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebUI.Controllers.MasterData;


public class CablesController : MasterdataControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<GetCablesResponse>>> Get()
    {
        return await Mediator.Send(new GetCablesQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CableDetailVm>> Get(string id)
    {
        return await Mediator.Send(new GetCableDetailQuery { Id = id });
    }


    [HttpGet("query")]
    public async Task<ActionResult<List<CablesByOemVm>>> GetByOem([FromQuery(Name = "byOemId")] string id)
    {
        return await Mediator.Send(new GetCablesByOemQuery { oemId = id });
    }


      [HttpPost]
    public async Task<ActionResult<RequestResponseMessage>> Create([FromForm] CreateCableCommand command)
    {

        var res = await Mediator.Send(command);

        if (res.Succeed)
            return Ok(res);

        return BadRequest(res);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<RequestResponseMessage>> Update(Guid id, [FromForm] UpdateCableCommand command)
    {

        if (command == null)
        {
            return BadRequest();
        }

        if (id != command.Id)
        {
            return BadRequest();
        }


        var res = await Mediator.Send(command);

        if (res.Succeed)
            return Ok(res);

        return BadRequest(res);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<RequestResponseMessage>> Delete(string id)
    {

        var res = await Mediator.Send(new DeleteCableCommand { Id = id });

        if (res.Succeed)
            return Ok(res);

        return BadRequest(res);
    }
}
