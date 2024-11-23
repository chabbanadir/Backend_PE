using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Application.Features.DrawingGenerator.step3.GetComponentsByOem.Dto;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using MediatR;

namespace Backend.Application.Features.DrawingGenerator.step3.GetComponentsByOem;

public class GetComponentsByOemQueryHandler : IRequestHandler<GetComponentsByOemQuery, List<ComponentsByOemVm>>
{

    private readonly IAsyncRepository<Component> _asyncRepository;
    private readonly IMapper _mapper;

    public GetComponentsByOemQueryHandler(IAsyncRepository<Component> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<List<ComponentsByOemVm>> Handle(GetComponentsByOemQuery request, CancellationToken cancellationToken)
    {
        // var item = await _asyncRepository.GetByIdAsync(new Guid(request.oemId), new[] { "Components", "Components.Config", "Components.Config.Picture","Components.Picture" }, cancellationToken);
/*
        var oem = await _asyncRepository.GetByAsync(x => x.Id == new Guid(request.oemId) || x.Name == "GENERAL" && x.Status == Status.Active, new[] { "Components", "Components.Config", "Components.Picture"*//*"ComponentChilds.ComponentChilds" , "ComponentChilds.Cable"*//* }, cancellationToken);


        if (oem == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

       // return _mapper.Map<ComponentsByOemVm>(oem);
        */


        var Components = await _asyncRepository.GetByAsync(x => x.Oem.Id == new Guid(request.oemId) && x.Status == Status.Active, new[] { "Config", "Config.Picture", "Picture" }, cancellationToken);
        return _mapper.Map<List<ComponentsByOemVm>>(Components);

    }
}
