using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Application.Features.Common.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Features.DrawingData.Queries.GetDrawingDatas
{
    public class GetDrawingDatasQueryHandler : IRequestHandler<GetDrawingDatasQuery, List<DrawingDataDto>>
    {
        private readonly IAsyncRepository<Backend.Domain.Entities.DrawingData> _repository;
        private readonly IMapper _mapper;

        public GetDrawingDatasQueryHandler(IAsyncRepository<Backend.Domain.Entities.DrawingData> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DrawingDataDto>> Handle(GetDrawingDatasQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all drawing data from the repository
            var drawingDataList = await _repository.GetAllAsync(null, cancellationToken);

            // Map the drawing data entities to DTOs
            var drawingDataDtoList = _mapper.Map<List<DrawingDataDto>>(drawingDataList);

            return drawingDataDtoList;
        }
    }
}
