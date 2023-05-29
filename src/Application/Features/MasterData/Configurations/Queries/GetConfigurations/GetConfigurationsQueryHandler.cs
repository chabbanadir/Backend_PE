using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Configurations.Queries.GetConfigurations;

public class GetConfigurationsQueryHandler : IRequestHandler<GetConfigurationsQuery, List<GetConfigurationsResponse>>
{
    private readonly IAsyncRepository<Config> asyncRepository;
    private readonly IMapper _mapper;

    public GetConfigurationsQueryHandler(IAsyncRepository<Config> asyncRepository, IMapper mapper)
    {
        this.asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<List<GetConfigurationsResponse>> Handle(GetConfigurationsQuery request, CancellationToken cancellationToken)
    {

        var query = await asyncRepository.GetAllAsync(new[] { "Picture", "Oem" , "Note"}, cancellationToken);

        return _mapper.Map<List<GetConfigurationsResponse>>(query);

    }

}