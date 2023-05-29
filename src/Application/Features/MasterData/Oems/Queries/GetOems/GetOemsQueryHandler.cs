using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Oems.Queries.GetOems;

public class GetOemsQueryHandler : IRequestHandler<GetOemsQuery, List<GetOemsResponse>>
{
    private readonly IAsyncRepository<Oem> _asyncRepository;
    private readonly IMapper _mapper;

    public GetOemsQueryHandler(IAsyncRepository<Oem> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<List<GetOemsResponse>> Handle(GetOemsQuery request, CancellationToken cancellationToken)
    {

        var oems = await _asyncRepository.GetAllAsync(null, cancellationToken);

        return _mapper.Map<List<GetOemsResponse>>(oems);
    }

}