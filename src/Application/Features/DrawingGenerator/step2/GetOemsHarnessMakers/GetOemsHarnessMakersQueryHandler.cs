using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Application.Features.DrawingGenerator.step2.GetOemsHarnessMakers.Dto;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using MediatR;

namespace Backend.Application.Features.DrawingGenerator.step2.GetOemsHarnessMakers;

public class GetOemsHarnessMakersQueryHandler : IRequestHandler<GetOemsHarnessMakersQuery, OemsHarnessMakersVm>
{
    private readonly IAsyncRepository<Oem> _asyncOemRepository;
    private readonly IAsyncRepository<Harnessmaker> _asyncHarnessRepository;
    private readonly IMapper _mapper;

    public GetOemsHarnessMakersQueryHandler(
        IAsyncRepository<Oem> asyncOemRepository,
        IAsyncRepository<Harnessmaker> asyncHarnessRepository,
        IMapper mapper)
    {
        _asyncOemRepository = asyncOemRepository;
        _asyncHarnessRepository = asyncHarnessRepository;
        _mapper = mapper;
    }

    public async Task<OemsHarnessMakersVm> Handle(GetOemsHarnessMakersQuery request, CancellationToken cancellationToken)
    {

        var oems = await _asyncOemRepository.GetAllAsync(null, cancellationToken);
        var harnesses = await _asyncHarnessRepository.GetAllAsync(null, cancellationToken);
        
        oems = oems.Where(item => item.Status == Status.Active).ToList();
        harnesses = harnesses.Where(item => item.Status == Status.Active).ToList();


        return new OemsHarnessMakersVm
        {
            Oems = _mapper.Map<IList<OemDto>>(oems),
            HarnessMakers = _mapper.Map<IList<HarnessMakersDto>>(harnesses),
        };
    }

}