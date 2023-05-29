using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Application.Features.DrawingData.Commands;
using Backend.Application.Features.DrawingData.Dtos;
using Backend.Application.Common.Interfaces;
using Backend.Application.Common.Exceptions;

namespace Backend.Infrastructure.Services
{
    public class DrawingDataService : IDrawingDataService
    {
        private readonly IAsyncRepository<Backend.Domain.Entities.DrawingData> _drawingDataRepository;
        private readonly IMapper _mapper;

        public DrawingDataService(IAsyncRepository<Backend.Domain.Entities.DrawingData> drawingDataRepository, IMapper mapper)
        {
            _drawingDataRepository = drawingDataRepository;
            _mapper = mapper;
        }

        public async Task<SaveDrawingDataResponse> SaveDrawingData(SaveDrawingDataCommand command)
        {
            // Implementation for saving drawing data
            // ...
            // Map the command to the entity
            var drawingDataEntity = _mapper.Map<Backend.Domain.Entities.DrawingData>(command);

            // Save the drawing data entity
            await _drawingDataRepository.Create(drawingDataEntity);
            
            
            return new SaveDrawingDataResponse(); // Add an appropriate response object or result
        }

        public async Task<DrawingDataDto> GetDrawingDataById(string id)
        {
            if (!Guid.TryParse(id, out var drawingDataId))
            {
                throw new ArgumentException("Invalid ID format.");
            }

            var drawingData = await _drawingDataRepository.GetByIdAsync(drawingDataId);

            if (drawingData == null)
            {
                throw new NotFoundException("DrawingData", drawingDataId);
            }

            var drawingDataDto = new DrawingDataDto
            {
                Id = drawingData.Id,
                TEPartNumber = drawingData.TEPartNumber,
                CustomerPN = drawingData.CustomerPN,
                ProjectNumber = drawingData.ProjectNumber,
                OEM = drawingData.OEM,
                HarnessMaker = drawingData.HarnessMaker,
                NumberOfConnectors = drawingData.NumberOfConnectors,
                Components = _mapper.Map<List<ComponentWithSideDto>>(drawingData.Components)
            };

            return drawingDataDto;
        }

        public async Task<IEnumerable<DrawingDataDto>> GetAllDrawingDataAsync()
        {
            var drawingDataList = await _drawingDataRepository.GetAllAsync();

            var drawingDataDtoList = drawingDataList.Select(drawingData => new DrawingDataDto
            {
                Id = drawingData.Id,
                TEPartNumber = drawingData.TEPartNumber,
                CustomerPN = drawingData.CustomerPN,
                ProjectNumber = drawingData.ProjectNumber,
                OEM = drawingData.OEM,
                HarnessMaker = drawingData.HarnessMaker,
                NumberOfConnectors = drawingData.NumberOfConnectors,
                Components = _mapper.Map<List<ComponentWithSideDto>>(drawingData.Components)
            });

            return drawingDataDtoList;
        }
    }
}