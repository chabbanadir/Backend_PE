using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Cables.Queries.GetCables;

public class GetCablesQueryHandler : IRequestHandler<GetCablesQuery, List<GetCablesResponse>>
{
    private readonly IAsyncRepository<Cable> _asyncRepository;
    private readonly IMapper _mapper;

    public GetCablesQueryHandler(IAsyncRepository<Cable> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<List<GetCablesResponse>> Handle(GetCablesQuery request, CancellationToken cancellationToken)
    {

        var query = await _asyncRepository.GetAllAsync(new[] { "Oem" }, cancellationToken);


        return _mapper.Map<List<GetCablesResponse>>(query);

    }

}