namespace Backend.WebUI.Controllers.MasterData;

using Backend.Application.Common.Exceptions;
using Backend.Application.Features.MasterData.Packages.Commands.DeletePackage;
using Backend.Application.Features.MasterData.Packages.Commands.UpdatePackage;
using Backend.Application.Features.MasterData.Packages.Queries.GetPackageDetail;
using Backend.Application.Features.MasterData.Packages.Queries.GetPackages;
using Backend.Application.Features.MasterData.Packagess.Commands.CreatePackage;
using Microsoft.AspNetCore.Mvc;

public class PackagesController : MasterdataControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<PackagesResponse>>> Get()
    {
        return await Mediator.Send(new GetPackagesQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PackageDetailVm>> Get(string id)
    {
        return await Mediator.Send(new GetPackageDetailQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<RequestResponseMessage>> Create(CreatePackageCommand command)
    {
        var res = await Mediator.Send(command);

        return res.Succeed ? Ok(res) : BadRequest(res);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RequestResponseMessage>> Update(Guid id, UpdatePackageCommand command)
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

        var res = await Mediator.Send(new DeletePackageCommand { Id = id });

        return res.Succeed ? Ok(res) : BadRequest(res);
    }
}
