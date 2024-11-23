using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Queries.GetComponents;

public class GetComponentsQueryHandler : IRequestHandler<GetComponentsQuery, List<GetComponentsResponse>>
{
    private readonly IAsyncRepository<Component> asyncRepository;
    private readonly IMapper _mapper;

    public GetComponentsQueryHandler(IAsyncRepository<Component> asyncRepository, IMapper mapper)
    {
        this.asyncRepository = asyncRepository;
        _mapper = mapper;
    }



    public async Task<List<GetComponentsResponse>> Handle(GetComponentsQuery request, CancellationToken cancellationToken)
    {
        var query = await asyncRepository.GetAllAsync(null, cancellationToken);

        return _mapper.Map<List<GetComponentsResponse>>(query);
    }

}