using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.DrawingData.Dtos;
using Backend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Backend.Application.Features.DrawingData.Commands
{
    public class SaveDrawingDataCommand :  IRequest<SaveDrawingDataResponse>
    {
        public string? TEPartNumber { get; set; }
        public string? CustomerPN { get; set; }
        public string? ProjectNumber { get; set; }
        public string? OEM { get; set; }
        public string? HarnessMaker { get; set; }
        public int NumberOfConnectors { get; set; }
        public List<ComponentWithSideDto>? Components { get; set; }
        public IFormFile? Pdf1 { get; set; }
        public IFormFile? Pdf2 { get; set; }
        public IFormFile? ExcelFile { get; set; }
    }

    public class SaveDrawingDataCommandProfile : IMapFrom<Backend.Domain.Entities.DrawingData>,IRequest<SaveDrawingDataResponse>
    {
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<SaveDrawingDataCommand, Backend.Domain.Entities.DrawingData>()
                .ForMember(dest => dest.Components, opt => opt.MapFrom(src => src.Components));
        }
    }
}
