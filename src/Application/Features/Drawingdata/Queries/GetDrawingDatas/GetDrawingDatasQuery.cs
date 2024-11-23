using MediatR;
using System.Collections.Generic;
using Backend.Application.Features.Common.Dtos;

namespace Backend.Application.Features.DrawingData.Queries.GetDrawingDatas
{
    public class GetDrawingDatasQuery : IRequest<List<DrawingDataDto>>
    {
        // You can add any additional parameters or filters if needed
    }
}
