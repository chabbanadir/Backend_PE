using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Backend.Application.Features.Drawings.Queries.GetDrawingDetail
{
    public class DrawingDataDetailVm : IMapFrom<Backend.Domain.Entities.DrawingData>
    {
        public Guid Guid { get; set; }
        public string TEPartNumber { get; set; }
        public string CustomerPN { get; set; }
        public string ProjectNumber { get; set; }
        public string OEM { get; set; }
        public string HarnessMaker { get; set; }
        public int NumberOfConnectors { get; set; }
        public List<ComponentWithSide> Components { get; set; }
        public string CDPath { get; set; }
        public string PDPath { get; set; }
        public string ExcelFilePath { get; set; }
        public string ImagePath { get; set; }

        // Other properties and relationships as needed

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Backend.Domain.Entities.DrawingData, DrawingDataDetailVm>().ReverseMap();
        }
    }
}
