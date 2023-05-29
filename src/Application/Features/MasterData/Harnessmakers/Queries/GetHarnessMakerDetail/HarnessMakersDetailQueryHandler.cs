using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;


namespace Backend.Application.Features.MasterData.Harnessmakers.Queries.GetHarnessMakerDetail;

public class HarnessMakersDetailQueryHandler : IRequestHandler<HarnessMakersDetailQuery, HarnessMakersDetailVm>
{

    private readonly IAsyncRepository<Harnessmaker> _asyncRepository;
    private readonly IMapper _mapper;

    public HarnessMakersDetailQueryHandler(IAsyncRepository<Harnessmaker> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<HarnessMakersDetailVm> Handle(HarnessMakersDetailQuery request, CancellationToken cancellationToken)
    {


        var item = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null, cancellationToken);

        if (item == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }


        return _mapper.Map<HarnessMakersDetailVm>(item);

    }
}
