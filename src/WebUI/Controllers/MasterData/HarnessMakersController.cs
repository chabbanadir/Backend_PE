using Backend.Application.Common.Exceptions;
using Backend.Application.Features.MasterData.Harnessmakers.Commands.CreateHarnessmaker;
using Backend.Application.Features.MasterData.Harnessmakers.Commands.DeleteHarnessmaker;
using Backend.Application.Features.MasterData.Harnessmakers.Commands.UpdateHarnessmaker;
using Backend.Application.Features.MasterData.Harnessmakers.Queries.GetHarnessMakerDetail;
using Backend.Application.Features.MasterData.Harnessmakers.Queries.GetHarnessMakers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebUI.Controllers.MasterData;

public class HarnessMakersController : MasterdataControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<HarnessMakersResponse>>> Get()
    {
        return await Mediator.Send(new GetHarnessMakersQuery());

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HarnessMakersDetailVm>> Get(string id)
    {
        return await Mediator.Send(new HarnessMakersDetailQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<RequestResponseMessage>> Create(CreateHarnessmakerCommand command)
    {
        var res = await Mediator.Send(command);

        return res.Succeed ? Ok(res) : BadRequest(res);
    }



    [HttpPut("{id}")]
    public async Task<ActionResult<RequestResponseMessage>> Update(Guid id, UpdateHarnessmakerCommand command)
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

        var res = await Mediator.Send(new DeleteHarnessmakerCommand { Id = id });

        return res.Succeed ? Ok(res) : BadRequest(res);
    }
}
