using Backend.Application.Common.Exceptions;

using Backend.Application.Features.MasterData.Infos.Commands.DeleteInfo;
using Backend.Application.Features.MasterData.Cables.Commands.UpdateCable;
using Backend.Application.Features.MasterData.Cables.Queries.GetCableDetail;
using Backend.Application.Features.MasterData.Infos.Queries.GetInfosByHarnessMaker;
using Backend.Application.Features.MasterData.Infos.Commands.CreateInfo;
using Backend.Application.Features.MasterData.Infos.Queries.GetInfos;
using Backend.Application.Features.MasterData.Infos.Queries.GetInfosByOem;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.Features.MasterData.Infos.Queries.GetInfoDetail;
using Backend.Application.Features.MasterData.Infos.Commands.UpdateInfo;

namespace Backend.WebUI.Controllers.MasterData;
public class InfosController : MasterdataControllerBase
{
    #region GET

    [HttpGet]
    public async Task<ActionResult<List<GetInfosResponse>>> Get()
    {
        return await Mediator.Send(new GetInfosQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InfoDetailVm>> Get(string id)
    {
        return await Mediator.Send(new GetInfoDetailQuery { Id = id });
    }

    [HttpGet("query")]
    public async Task<ActionResult<List<InfosByOemVm>>> GetByOem([FromQuery(Name = "byOemId")] string id, string cableId, string categoryId)
    {
        return await Mediator.Send(new GetInfosByOemQuery { oemId = id });
    }
 
    #endregion


    [HttpPost]
    public async Task<ActionResult<RequestResponseMessage>> Create([FromForm] CreateInfoCommand command)
    {

        var res = await Mediator.Send(command);

        if (res.Succeed)
            return Ok(res);

        return BadRequest(res);
    }

    #region Put

    [HttpPut("{id}")]
    public async Task<ActionResult<RequestResponseMessage>> Update(Guid id, [FromForm] UpdateInfoCommand command)
    {

        if (command == null)
        {
            return BadRequest();
        }

        if (id != new Guid(command.Id))
        {
            return BadRequest();
        }


        var item = await Mediator.Send(command);

        return item.Succeed ? Ok(item) : (ActionResult<RequestResponseMessage>)BadRequest(item);
    }

    /*[HttpPut("{id}/details")]
    public async Task<ActionResult<RequestResponseMessage>> UpdateDetails(Guid id, [FromForm] UpdateComponentDetailCommand command)
    {

        if (command == null)
        {
            return BadRequest();
        }

        if (id != new Guid(command.Id))
        {
            return BadRequest();
        }


        var item = await Mediator.Send(command);

        return item.Succeed ? Ok(item) : (ActionResult<RequestResponseMessage>)BadRequest(item);
    }

    #endregion*/


    #region Delete
    [HttpDelete("{id}")]
    public async Task<ActionResult<RequestResponseMessage>> Delete(Guid id)
    {
        var res = await Mediator.Send(new DeleteInfoCommand { Id = id });

        return res.Succeed ? Ok(res) : (ActionResult<RequestResponseMessage>)BadRequest(res);
    }

    #endregion




    /*#region Parts

    [HttpGet("{id}/parts")]
    public async Task<ActionResult<GetComponentPartsVm>> GetComponentParts(string id)
    {
        return await Mediator.Send(new GetComponentPartsQuery { Id = id });
    }


    [HttpPost("parts")]
    public async Task<ActionResult<RequestResponseMessage>> AddPart(AddPartCommand command)
    {
        if (command == null)
        { return BadRequest(); }
        var item = await Mediator.Send(command);
        return item.Succeed ? Ok(item) : (ActionResult<RequestResponseMessage>)BadRequest(item);
    }


    [HttpDelete("parts/{id}")]
    public async Task<ActionResult<RequestResponseMessage>> DeletePart(string id)
    {
        var res = await Mediator.Send(new DeletePartCommand { Id = id });
        return res.Succeed ? Ok(res) : (ActionResult<RequestResponseMessage>)BadRequest(res);
    }

    #endregion

    #region Cables

    [HttpGet("{id}/cables")]
    public async Task<ActionResult<GetComponentCablesVm>> GetComponentCables(string id)
    {
        return await Mediator.Send(new GetComponentCablesQuery { Id = id });
    }

    [HttpPost("cables")]
    public async Task<ActionResult<RequestResponseMessage>> AddCable(AddCableCommand command)
    {
        if (command == null)
        { return BadRequest(); }
        var item = await Mediator.Send(command);
        return item.Succeed ? Ok(item) : (ActionResult<RequestResponseMessage>)BadRequest(item);
    }

    [HttpDelete("cables/{id}")]
    public async Task<ActionResult<RequestResponseMessage>> DeleteCable(string id)
    {
        var res = await Mediator.Send(new DeleteCableCommand { Id = id });
        return res.Succeed ? Ok(res) : (ActionResult<RequestResponseMessage>)BadRequest(res);
    }
    */
    #endregion



}