﻿using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Backend.WebUI.Controllers;

[ApiController]
[Route("api/data/[controller]")]
public abstract class MasterdataControllerBase : ControllerBase
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();


    protected bool ValidateGuid(string id)
    {
        return Guid.TryParse(id, out var result);
    }
}
