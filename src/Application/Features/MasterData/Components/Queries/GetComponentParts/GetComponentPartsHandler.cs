using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponentParts;


public class GetComponentPartsHandler : IRequestHandler<GetComponentPartsQuery, GetComponentPartsVm>
{
    private readonly IAsyncRepository<Component> _asyncRepository;
    private readonly IMapper _mapper;

    public GetComponentPartsHandler(IAsyncRepository<Component> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<GetComponentPartsVm> Handle(GetComponentPartsQuery request, CancellationToken cancellationToken)
    {

        var component = await _asyncRepository.GetByIdAsync(new Guid(request.Id), new[] { "Parts"}, cancellationToken);;
        component.Parts = component.Parts.Where(x => !x.IsDeleted).ToList();

        return component == null
            ? throw new NotFoundException("The specified Id is not exists.")
            : _mapper.Map<GetComponentPartsVm>(component);
    }

}