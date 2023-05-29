using Backend.Application.Common.Exceptions;
using Backend.Application.Features.MasterData.Notes.Commands.CreateNote;
using Backend.Application.Features.MasterData.Notes.Commands.DeleteNote;
using Backend.Application.Features.MasterData.Notes.Commands.UpdateNote;
using Backend.Application.Features.MasterData.Notes.Queries.GetNoteDetail;
using Backend.Application.Features.MasterData.Notes.Queries.GetNotes;
using Backend.Application.Features.MasterData.Notes.Queries.GetNotesByType;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebUI.Controllers.MasterData;


public class NotesController : MasterdataControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<GetNotesResponse>>> Get()
    {
        return await Mediator.Send(new GetNotesQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NoteDetailVm>> Get(string id)
    {
        return await Mediator.Send(new GetNoteDetailQuery { Id = id });
    }
    
    [HttpGet("type/{id}")]
    public async Task<ActionResult<List<GetNotesByTypeResponse>>> GetByType(int id)
    {
        return await Mediator.Send(new GetNotesByTypeQuery { type = id });
    }


    [HttpPost]
    public async Task<ActionResult<RequestResponseMessage>> Create([FromForm] CreateNoteCommand command)
    {
        var res = await Mediator.Send(command);

        return res.Succeed ? Ok(res) : BadRequest(res);

    }



    [HttpPut("{id}")]
    public async Task<ActionResult<RequestResponseMessage>> Update(Guid id, [FromForm] UpdateNoteCommand command)
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
        var res = await Mediator.Send(new DeleteNoteCommand { Id = id });
        return res.Succeed ? Ok(res) : BadRequest(res);
    }



    /* [HttpGet]
     public async Task<ActionResult<GetCablesVm>> Get()
     {
         return await Mediator.Send(new GetCablesQuery());
     }

     [HttpDelete("{id}")]
     public async Task<ActionResult> Delete(Guid id)
     {
         await Mediator.Send(new DeleteCableCommand { Id = id });

         return NoContent();
     }

     [HttpPut("{id}")]
     public async Task<ActionResult> Update(Guid id, UpdateCableCommand command)
     {
         if (id != command.Id)
         {
             return BadRequest();
         }

         await Mediator.Send(command);

         return NoContent();
     }*/
}
