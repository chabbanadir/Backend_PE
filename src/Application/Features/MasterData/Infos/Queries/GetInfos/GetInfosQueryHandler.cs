using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Infos.Queries.GetInfos;

public class GetInfosQueryHandler : IRequestHandler<GetInfosQuery, List<GetInfosResponse>>
{
    private readonly IAsyncRepository<Info> _asyncRepository;
    private readonly IMapper _mapper;

    public GetInfosQueryHandler(IAsyncRepository<Info> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<List<GetInfosResponse>> Handle(GetInfosQuery request, CancellationToken cancellationToken)
    {

        var query = await _asyncRepository.GetAllAsync(new[] { "Oem" }, cancellationToken);


        return _mapper.Map<List<GetInfosResponse>>(query);

    }

}