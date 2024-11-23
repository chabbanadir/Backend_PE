using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;


namespace Backend.Application.Features.MasterData.Cables.Queries.GetCableDetail;

public class GetCableDetailQueryHandler : IRequestHandler<GetCableDetailQuery, CableDetailVm>
{
    private readonly IAsyncRepository<Cable> _asyncRepository;
    private readonly IMapper _mapper;

    public GetCableDetailQueryHandler(IAsyncRepository<Cable> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<CableDetailVm> Handle(GetCableDetailQuery request, CancellationToken cancellationToken)
    {

        var item = await _asyncRepository.GetByIdAsync(new Guid(request.Id), new[] { "Oem" }, cancellationToken);

        if (item == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

        return _mapper.Map<CableDetailVm>(item);

    }

}
