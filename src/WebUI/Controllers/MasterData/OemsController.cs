using Backend.Application.Common.Exceptions;
using Backend.Application.Features.MasterData.Oems.Commands.CreateOem;
using Backend.Application.Features.MasterData.Oems.Commands.DeleteOem;
using Backend.Application.Features.MasterData.Oems.Commands.UpdateOem;
using Backend.Application.Features.MasterData.Oems.Queries.GetOemDetail;
using Backend.Application.Features.MasterData.Oems.Queries.GetOems;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebUI.Controllers.MasterData;


public class OemsController : MasterdataControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<GetOemsResponse>>> Get()
    {
        return await Mediator.Send(new GetOemsQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OemDetailVm>> Get(string id)
    {
        return await Mediator.Send(new GetOemDetailQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<RequestResponseMessage>> Create(CreateOemCommand command)
    {
        var res = await Mediator.Send(command);

        return res.Succeed ? Ok(res) : BadRequest(res);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RequestResponseMessage>> Update(Guid id, UpdateOemCommand command)
    {

        if (command == null || id != command.Id)
        {
            return BadRequest();
        }

        var res = await Mediator.Send(command);

        return res.Succeed ? Ok(res) : BadRequest(res);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<RequestResponseMessage>> Delete(string id)
    {
        var res = await Mediator.Send(new DeleteOemCommand { Id = id });

        return res.Succeed ? Ok(res) : BadRequest(res);
    }

}
