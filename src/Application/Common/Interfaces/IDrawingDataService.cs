using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Application.Features.DrawingData.Commands;
using Backend.Application.Features.DrawingData.Dtos;

namespace Backend.Application.Common.Interfaces
{
    public interface IDrawingDataService
    {
        Task<SaveDrawingDataResponse> SaveDrawingData(SaveDrawingDataCommand command);
        Task<DrawingDataDto> GetDrawingDataById(string id);
        Task<IEnumerable<DrawingDataDto>> GetAllDrawingDataAsync();
    }
}
