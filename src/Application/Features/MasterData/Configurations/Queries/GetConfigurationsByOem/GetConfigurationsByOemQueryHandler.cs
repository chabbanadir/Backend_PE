using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using MediatR;

namespace Backend.Application.Features.MasterData.Configurations.Queries.GetConfigurationsByOem;

public class GetConfigurationsByOemQueryHandler : IRequestHandler<GetConfigurationsByOemQuery, List<ConfigurationsByOemVm>>
{
    private readonly IAsyncRepository<Config> _asyncRepository;
    private readonly IMapper _mapper;


    public GetConfigurationsByOemQueryHandler(
        IAsyncRepository<Config> asyncRepository,
        IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<List<ConfigurationsByOemVm>> Handle(GetConfigurationsByOemQuery request, CancellationToken cancellationToken)
    {

        var configs = await _asyncRepository.GetByAsync(x => x.Oem.Id == new Guid(request.oemId) && x.Status == Status.Active,null ,cancellationToken);
        return _mapper.Map<List<ConfigurationsByOemVm>>(configs);

    }

}