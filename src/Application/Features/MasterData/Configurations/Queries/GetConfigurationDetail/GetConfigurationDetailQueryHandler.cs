using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Configurations.Queries.GetConfigurationDetail;

public class GetConfigurationDetailQueryHandler : IRequestHandler<GetConfigurationDetailQuery, ConfigurationDetailVm>
{
    private readonly IAsyncRepository<Config> _asyncRepository;
    private readonly IMapper _mapper;

    public GetConfigurationDetailQueryHandler(IAsyncRepository<Config> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<ConfigurationDetailVm> Handle(GetConfigurationDetailQuery request, CancellationToken cancellationToken)
    {


        var item = await _asyncRepository.GetByIdAsync(new Guid(request.Id), new[] { "Oem", "Picture", "Note" }, cancellationToken);

        if (item == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }


        return _mapper.Map<ConfigurationDetailVm>(item);

    }
}
