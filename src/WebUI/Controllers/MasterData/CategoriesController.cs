using Backend.Application.Common.Exceptions;
using Backend.Application.Features.MasterData.Categories.Commands.CreateCategory;
using Backend.Application.Features.MasterData.Categories.Commands.DeleteCategory;
using Backend.Application.Features.MasterData.Categories.Commands.UpdateCategory;
using Backend.Application.Features.MasterData.Categories.Queries.GetCategories;
using Backend.Application.Features.MasterData.Categories.Queries.GetCategoryDetail;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebUI.Controllers.MasterData;


public class CategoriesController : MasterdataControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<GetCategoriesResponse>>> Get()
    {
        return await Mediator.Send(new GetCategoriesQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDetailVm>> Get(string id)
    {
        return await Mediator.Send(new GetCategoryDetailQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<RequestResponseMessage>> Create(CreateCategoryCommand command)
    {
        var res = await Mediator.Send(command);

        return res.Succeed ? Ok(res) : BadRequest(res);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RequestResponseMessage>> Update(Guid id, UpdateCategoryCommand command)
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

        var res = await Mediator.Send(new DeleteCategoryCommand { Id = id });

        return res.Succeed ? Ok(res) : BadRequest(res);
    }


}
