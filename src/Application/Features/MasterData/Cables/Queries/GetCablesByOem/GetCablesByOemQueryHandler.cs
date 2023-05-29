using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using MediatR;

namespace Backend.Application.Features.MasterData.Cables.Queries.GetCablesByOem;
public class GetCablesByOemQueryHandler : IRequestHandler<GetCablesByOemQuery, List<CablesByOemVm>>
{
    private readonly IAsyncRepository<Cable> _asyncRepository;
    private readonly IMapper _mapper;


    public GetCablesByOemQueryHandler(
        IAsyncRepository<Cable> asyncRepository,
        IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<List<CablesByOemVm>> Handle(GetCablesByOemQuery request, CancellationToken cancellationToken)
    {

        var configs = await _asyncRepository.GetByAsync(x => x.Oem.Id == new Guid(request.oemId) && x.Status == Status.Active, null, cancellationToken);
        return _mapper.Map<List<CablesByOemVm>>(configs);

    }

}