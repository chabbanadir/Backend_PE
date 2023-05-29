using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities;
using Backend.Application.Features.DrawingData.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Common.Interfaces;

namespace Backend.Application.Features.DrawingData.Commands
{
    public class SaveDrawingDataCommandHandler : IRequestHandler<SaveDrawingDataCommand, SaveDrawingDataResponse>
{
    private readonly IAsyncRepository<Backend.Domain.Entities.DrawingData> _drawingDataRepository;
    private readonly IMapper _mapper;
    private readonly IFileStorageService _fileStorageService;

    public SaveDrawingDataCommandHandler(IAsyncRepository<Backend.Domain.Entities.DrawingData> drawingDataRepository, IMapper mapper, IFileStorageService fileStorageService)
    {
        _drawingDataRepository = drawingDataRepository;
        _mapper = mapper;
        _fileStorageService = fileStorageService;
    }

    public async Task<SaveDrawingDataResponse> Handle(SaveDrawingDataCommand request, CancellationToken cancellationToken)
    {
        var drawingData = new Backend.Domain.Entities.DrawingData
        {
            TEPartNumber = request.TEPartNumber,
            CustomerPN = request.CustomerPN,
            ProjectNumber = request.ProjectNumber,
            OEM = request.OEM,
            HarnessMaker = request.HarnessMaker,
            NumberOfConnectors = request.NumberOfConnectors,
            Components = request.Components?.Select(c => _mapper.Map<ComponentWithSide>(c)).ToList()
        };

       
        // Save the PDF and Excel file
        await SavePdfFile(request.Pdf1, drawingData.TEPartNumber  + "PD.pdf");
        await SavePdfFile(request.Pdf2,  drawingData.TEPartNumber  +"CD.pdf");
        await SaveExcelFile(request.ExcelFile,  drawingData.TEPartNumber  +"SmartAssembly.xlsm");
        
        //  Add the files paths to DrawingData
        drawingData.CDPath = await SavePdfFile(request.Pdf1, drawingData.TEPartNumber + "PD.pdf");
        drawingData.PDPath = await SavePdfFile(request.Pdf2, drawingData.TEPartNumber + "CD.pdf");
        drawingData.ExcelFilePath = await SaveExcelFile(request.ExcelFile, drawingData.TEPartNumber + "SmartAssembly.xlsm");

        
         await _drawingDataRepository.Create(drawingData, cancellationToken);


        var response = new SaveDrawingDataResponse
        {
            Message = "Drawing data saved successfully",
            Succeed = true,
            // You can set any other properties in the response as needed
        };

        return response;
    }

    private async Task<string> SavePdfFile(IFormFile file, string fileName)
    {
        if (file != null && file.Length > 0)
        {
            // Save the file using the file storage service
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                await _fileStorageService.SaveFile(stream.ToArray(), fileName);
            }

            // Return the file path
            return _fileStorageService.GetFilePath(fileName);
        }

        return null; // or throw an exception, depending on your requirement
    }

    private async Task<string> SaveExcelFile(IFormFile file, string fileName)
    {
        if (file != null && file.Length > 0)
        {
            // Save the file using the file storage service
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                await _fileStorageService.SaveFile(stream.ToArray(), fileName);
            }

            // Return the file path
            return _fileStorageService.GetFilePath(fileName);
        }

        return null; // or throw an exception, depending on your requirement
    }

}

}
