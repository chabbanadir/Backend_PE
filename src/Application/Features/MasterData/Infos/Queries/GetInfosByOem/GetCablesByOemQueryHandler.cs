using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Application.Features.MasterData.Infos.Queries.GetInfosByOem;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using MediatR;

namespace Backend.Application.Features.MasterData.Infos.Queries.GetInfosByOem;
public class GetInfosByOemQueryHandler : IRequestHandler<GetInfosByOemQuery, List<InfosByOemVm>>
{
    private readonly IAsyncRepository<Info> _asyncRepository;
    private readonly IMapper _mapper;


    public GetInfosByOemQueryHandler(
        IAsyncRepository<Info> asyncRepository,
        IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<List<InfosByOemVm>> Handle(GetInfosByOemQuery request, CancellationToken cancellationToken)
    {

        var configs = await _asyncRepository.GetByAsync(x => x.Oem.Id == new Guid(request.oemId), null, cancellationToken);
        return _mapper.Map<List<InfosByOemVm>>(configs);

    }

}