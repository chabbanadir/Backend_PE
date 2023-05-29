using System;
using System.Threading.Tasks;
using Backend.Application.Features.DrawingData.Commands;
using Backend.Application.Features.DrawingData.Dtos;
using Backend.Application.Features.DrawingData.Queries.GetDrawingDatas;
using Backend.Application.Features.Drawings.Queries.GetDrawingDetail;
using Backend.Application.Features.MasterData.Cables.Queries.GetCableDetail;
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
        
        


        [HttpGet("drawings/{id:guid}")]
        public async Task<ActionResult<DrawingDataDetailVm>> GetDrawingById(string id)
        {  
            var result = await _mediator.Send(new GetDrawingDataDetailQuery { Id = id });

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<DrawingDataDto>>> GetDrawingDatas()
        {
            var query = new GetDrawingDatasQuery();
            var drawingDatas = await _mediator.Send(query);

            return Ok(drawingDatas);
        }

    }
}
