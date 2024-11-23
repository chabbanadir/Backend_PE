using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using MediatR;


namespace Backend.Application.Features.DrawingGenerator.step4.GetCablesByOem;

public class GetCablesByOemQueryHandler : IRequestHandler<GetCablesByOemQuery, List<CablesByOemVm>>
{
    private readonly IAsyncRepository<Cable> _asyncRepository;
    private readonly IMapper _mapper;

    public GetCablesByOemQueryHandler(IAsyncRepository<Cable> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<List<CablesByOemVm>> Handle(GetCablesByOemQuery request, CancellationToken cancellationToken)
    {
       /* var item = await _asyncRepository.GetByIdAsync(new Guid(request.oemId), new[] { "Cables" }, cancellationToken);

        if (item == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

        return _mapper.Map<CablesByOemVm>(item);*/



        var Components = await _asyncRepository.GetByAsync(x => x.Oem.Id == new Guid(request.oemId) && x.Status == Status.Active, null , cancellationToken);
        return _mapper.Map<List<CablesByOemVm>>(Components);

    }
}