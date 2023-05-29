using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using MediatR;

namespace Backend.Application.Features.MasterData.Oems.Queries.GetComponents;

public class GetComponentsQueryHandler : IRequestHandler<GetComponentsQuery, ComponentsResponse>
{
    private readonly IAsyncRepository<Oem> _asyncRepository;
    private readonly IMapper _mapper;

    public GetComponentsQueryHandler(IAsyncRepository<Oem> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<ComponentsResponse> Handle(GetComponentsQuery request, CancellationToken cancellationToken)
    {
      //  var oem = await _asyncRepository.GetByAsync(x => (x.Id == new Guid(request.oemId) || x.Name == "GENERAL") && x.Status == Status.Active, new[] { "Components", "Components.Config", "Components.Picture"/*"ComponentChilds.ComponentChilds" , "ComponentChilds.Cable"*/ }, cancellationToken);


       var oem = await _asyncRepository.GetByIdAsync(new Guid(request.oemId), new[] { "Components" , "Components.Config", "Components.Picture"/*"ComponentChilds.ComponentChilds" , "ComponentChilds.Cable"*/ }, cancellationToken);


        if (oem == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

        return _mapper.Map<ComponentsResponse>(oem);

    }
}
