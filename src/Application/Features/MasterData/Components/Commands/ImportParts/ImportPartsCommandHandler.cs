using AutoMapper;
using Backend.Application.Common.Interfaces;
using Backend.Application.Common.Responses;
using Backend.Application.Contracts.Persistence;
using Backend.Application.Features.MasterData.Components.Commands.ImportParts.ClassMap;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Commands.ImportParts;

public class ImportPartsCommandHandler : IRequestHandler<ImportPartsCommand, ImportMessage>
{
    private readonly IAsyncRepository<ComponentPart> _repository;
    private readonly IMapper _mapper;
    private readonly ICsvImport<ImportPartMV, PartClassMap> _csvImport;
    public ImportPartsCommandHandler(IAsyncRepository<ComponentPart> repository, IMapper mapper, ICsvImport<ImportPartMV, PartClassMap> csvImport)
    {
        _repository = repository;
        _mapper = mapper;
        _csvImport = csvImport;
    }
    public async Task<ImportMessage> Handle(ImportPartsCommand request, CancellationToken cancellationToken)
    {
        var data = _csvImport.ReadInCSV(request.file);
        var req = new ImportMessage();
        if (data == null)
        {
            req.Message = request.file.FileName + " importation failed !";
            req.IsSucceed = false;
            return req;
        }
        // var mapCarrier = _mapper.Map<List<ImportCarrierMV>>(carrier);
        //var result = _mapper.Map<List<Carrier>>(mapCarrier);
        //  await _repository.AddRangeAsync(result);
        foreach (var map in data)
        {
            var result = _mapper.Map<ComponentPart>(map);
            var succeed = await _repository.Create(result);
            if (succeed != null)
            {
                req.SucccesCount += 1;
                req.Message = " Added Successfully !";
                req.IsSucceed = true;
            }
            else
            {
                req.FaildCount += 1;
                req.Message = " Adding failed !";
                req.IsSucceed = false;
            }
        }
        // when uplaod falses = false message
        return req;
    }
}