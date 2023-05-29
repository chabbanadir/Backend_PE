using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Harnessmakers.Queries.GetHarnessMakers;

public class GetHarnessMakersQueryHandler : IRequestHandler<GetHarnessMakersQuery, List<HarnessMakersResponse>>
{
    private readonly IAsyncRepository<Harnessmaker> _asyncRepository;
    private readonly IMapper _mapper;

    public GetHarnessMakersQueryHandler(IAsyncRepository<Harnessmaker> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<List<HarnessMakersResponse>> Handle(GetHarnessMakersQuery request, CancellationToken cancellationToken)
    {

        var harnessmakers = await _asyncRepository.GetAllAsync(null, cancellationToken);

        return _mapper.Map<List<HarnessMakersResponse>>(harnessmakers);
    }

}
