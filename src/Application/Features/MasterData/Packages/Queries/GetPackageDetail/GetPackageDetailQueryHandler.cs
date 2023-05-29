using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Packages.Queries.GetPackageDetail;


public class GetPackageDetailQueryHandler : IRequestHandler<GetPackageDetailQuery, PackageDetailVm>
{
    private readonly IAsyncRepository<Package> _asyncRepository;
    private readonly IMapper _mapper;

    public GetPackageDetailQueryHandler(IAsyncRepository<Package> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<PackageDetailVm> Handle(GetPackageDetailQuery request, CancellationToken cancellationToken)
    {


        var oem = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null, cancellationToken);

        if (oem == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }


        return _mapper.Map<PackageDetailVm>(oem);

    }

}