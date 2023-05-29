using System;
using System.Threading.Tasks;
using Backend.Application.Features.DrawingData.Commands;
using Backend.Application.Features.DrawingData.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.WebUI.Controllers
{
    [ApiController]
    [Route("api/drawing-data")]
    public class DrawingDataController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DrawingDataController> _logger;

        public DrawingDataController(IMediator mediator, ILogger<DrawingDataController>  logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> SaveDrawingData([FromForm] SaveDrawingDataCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the drawing data.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        
    }
}
