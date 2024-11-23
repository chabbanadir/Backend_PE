using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentDetail;


public class GetComponentDetailQueryHandler : IRequestHandler<GetComponentDetailQuery, ComponentDetailVm>
{
    private readonly IAsyncRepository<Component> _asyncRepository;
    private readonly IMapper _mapper;

    public GetComponentDetailQueryHandler(IAsyncRepository<Component> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<ComponentDetailVm> Handle(GetComponentDetailQuery request, CancellationToken cancellationToken)
    {
 
        var component = await _asyncRepository.GetByIdAsync(new Guid(request.Id), new[] { "Oem","Picture", "Category" , "Config", "Config.Picture","Parts" , "Parts.Part" }, cancellationToken);

        if (component == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

        return _mapper.Map<ComponentDetailVm>(component);

    }

}