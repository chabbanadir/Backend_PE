using Backend.Application.Common.Exceptions;
using Backend.Application.Features.MasterData.Configurations.Commands.CreateConfiguration;
using Backend.Application.Features.MasterData.Configurations.Commands.DeleteConfiguration;
using Backend.Application.Features.MasterData.Configurations.Commands.UpdateConfiguration;
using Backend.Application.Features.MasterData.Configurations.Queries.GetConfigurationDetail;
using Backend.Application.Features.MasterData.Configurations.Queries.GetConfigurations;
using Backend.Application.Features.MasterData.Configurations.Queries.GetConfigurationsByOem;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebUI.Controllers.MasterData;


public class ConfigurationsController : MasterdataControllerBase
{


    [HttpGet]
    public async Task<ActionResult<List<GetConfigurationsResponse>>> Get()
    {
        return await Mediator.Send(new GetConfigurationsQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ConfigurationDetailVm>> Get(string id)
    {
        return await Mediator.Send(new GetConfigurationDetailQuery { Id = id });
    }
    
    [HttpGet("query")]
    public async Task<IActionResult> GetByOem([FromQuery(Name = "byOemId")] string oemid)
    {
        return Ok(await Mediator.Send(new GetConfigurationsByOemQuery { oemId = oemid }));
    }

    [HttpPost]
    public async Task<ActionResult<RequestResponseMessage>> Create([FromForm] CreateInfoCommand command)
    {

        var res = await Mediator.Send(command);

        if (res.Succeed)
            return Ok(res);

        return BadRequest(res);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<RequestResponseMessage>> Update(Guid id, [FromForm] UpdateConfigurationCommand command)
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

        var res = await Mediator.Send(new DeleteConfigurationCommand { Id = id });

        if (res.Succeed)
            return Ok(res);

        return BadRequest(res);
    }

}
