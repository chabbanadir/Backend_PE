using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities;
using System.Collections.Generic;


namespace Backend.Application.Features.DrawingData
{
    public class DrawingDataDto : IMapFrom<Backend.Domain.Entities.DrawingData> 
    {

        public Guid Id {get; set;}
        public string? TEPartNumber { get; set; }
        public string? CustomerPN { get; set; }
        public string? ProjectNumber { get; set; }
        public string? OEM { get; set; }
        public string? HarnessMaker { get; set; }
        public int NumberOfConnectors { get; set; }
        public List<ComponentWithSideDto>? Components { get; set; }
    }

    public class ComponentWithSideDto
    {
        public ComponentDto? Component { get; set; }
        public Side Side { get; set; }
    }

}