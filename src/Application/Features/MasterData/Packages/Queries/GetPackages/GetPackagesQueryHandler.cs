using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;


namespace Backend.Application.Features.MasterData.Packages.Queries.GetPackages;


public class GetPackagesQueryHandler : IRequestHandler<GetPackagesQuery, List<PackagesResponse>>
{
    private readonly IAsyncRepository<Package> _asyncRepository;
    private readonly IMapper _mapper;

    public GetPackagesQueryHandler(IAsyncRepository<Package> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<List<PackagesResponse>> Handle(GetPackagesQuery request, CancellationToken cancellationToken)
    {

        var oems = await _asyncRepository.GetAllAsync(null, cancellationToken);

        return _mapper.Map<List<PackagesResponse>>(oems);
    }

}