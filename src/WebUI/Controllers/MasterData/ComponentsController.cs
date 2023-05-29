using Backend.Application.Common.Exceptions;

using Backend.Application.Features.MasterData.Components.Commands.Cables.AddCable;
using Backend.Application.Features.MasterData.Components.Commands.Cables.DeleteCable;

using Backend.Application.Features.MasterData.Components.Commands.Parts.AddPart;
using Backend.Application.Features.MasterData.Components.Commands.Parts.DeletePart;


using Backend.Application.Features.MasterData.Components.Commands.CreateComponent;
using Backend.Application.Features.MasterData.Components.Commands.DeleteComponent;
using Backend.Application.Features.MasterData.Components.Commands.UpdateComponent;
using Backend.Application.Features.MasterData.Components.Commands.UpdateComponentDetail;

using Backend.Application.Features.MasterData.Components.Queries.GetComponentDetail;
using Backend.Application.Features.MasterData.Components.Queries.GetComponentParts;
using Backend.Application.Features.MasterData.Components.Queries.GetComponents;
using Backend.Application.Features.MasterData.Components.Queries.GetComponentsByOem;

using Microsoft.AspNetCore.Mvc;
using Backend.Application.Features.MasterData.Components.Queries.GetComponentCables;

namespace Backend.WebUI.Controllers.MasterData;


public class ComponentsController : MasterdataControllerBase
{
    #region GET

        [HttpGet]
        public async Task<ActionResult<List<GetComponentsResponse>>> Get()
        {
            return await Mediator.Send(new GetComponentsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentDetailVm>> Get(string id)
        {
            return await Mediator.Send(new GetComponentDetailQuery { Id = id });
        }

        [HttpGet("query")]
        public async Task<ActionResult<List<ComponentsByOemVm>>> GetByOem([FromQuery(Name = "byOemId")] string id, string cableId, string categoryId)
        {
            return await Mediator.Send(new GetComponentsByOemQuery { oemId = id, cableId = cableId, categoryId = categoryId});
        }

    #endregion


    #region Post
   
        [HttpPost]
        public async Task<ActionResult<RequestResponseMessage>> Create([FromForm] CreateComponentCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var item = await Mediator.Send(command);

            return item.Succeed ? Ok(item) : (ActionResult<RequestResponseMessage>)BadRequest(item);
        }


    #endregion


    #region Put

        [HttpPut("{id}")]
        public async Task<ActionResult<RequestResponseMessage>> Update(Guid id, [FromForm] UpdateComponentCommand command)
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

        [HttpPut("{id}/details")]
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

    #endregion


    #region Delete
    [HttpDelete("{id}")]
    public async Task<ActionResult<RequestResponseMessage>> Delete(Guid id)
    {
        var res = await Mediator.Send(new DeleteComponentCommand { Id = id });

        return res.Succeed ? Ok(res) : (ActionResult<RequestResponseMessage>)BadRequest(res);
    }

    #endregion




    #region Parts

        [HttpGet("{id}/parts")]
        public async Task<ActionResult<GetComponentPartsVm>> GetComponentParts(string id)
        {
            return await Mediator.Send(new GetComponentPartsQuery { Id = id });
        }


        [HttpPost("parts")]
        public async Task<ActionResult<RequestResponseMessage>> AddPart(AddPartCommand command)
        {
            if (command == null)
                {return BadRequest();}
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
            {return BadRequest();}
            var item = await Mediator.Send(command);
            return item.Succeed ? Ok(item) : (ActionResult<RequestResponseMessage>)BadRequest(item);
        }

        [HttpDelete("cables/{id}")]
        public async Task<ActionResult<RequestResponseMessage>> DeleteCable(string id)
        {
            var res = await Mediator.Send(new DeleteCableCommand { Id = id });
            return res.Succeed ? Ok(res) : (ActionResult<RequestResponseMessage>)BadRequest(res);
        }

    #endregion


}
