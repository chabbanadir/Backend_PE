using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentCables;

public class GetComponentPartsHandler : IRequestHandler<GetComponentCablesQuery, GetComponentCablesVm>
{
    private readonly IAsyncRepository<Component> _asyncRepository;
    private readonly IMapper _mapper;

    public GetComponentPartsHandler(IAsyncRepository<Component> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<GetComponentCablesVm> Handle(GetComponentCablesQuery request, CancellationToken cancellationToken)
    {

        var component = await _asyncRepository.GetByIdAsync(new Guid(request.Id), new[] { "Cables" }, cancellationToken); ;
        component.Cables = component.Cables.Where(x => !x.IsDeleted).ToList();

        if (component == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

        return _mapper.Map<GetComponentCablesVm>(component);

    }

}