using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;


namespace Backend.Application.Features.MasterData.Infos.Queries.GetInfoDetail;

public class GetInfoDetailQueryHandler : IRequestHandler<GetInfoDetailQuery, InfoDetailVm>
{
    private readonly IAsyncRepository<Info> _asyncRepository;
    private readonly IMapper _mapper;

    public GetInfoDetailQueryHandler(IAsyncRepository<Info> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<InfoDetailVm> Handle(GetInfoDetailQuery request, CancellationToken cancellationToken)
    {

        var item = await _asyncRepository.GetByIdAsync(new Guid(request.Id), new[] { "Oem" }, cancellationToken);

        if (item == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

        return _mapper.Map<InfoDetailVm>(item);

    }

}
