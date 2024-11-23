using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Packages.Commands.UpdatePackage;

public class UpdatePackageCommandHandler : IRequestHandler<UpdatePackageCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Package> _asyncRepository;
    private readonly IMapper _mapper;

    public UpdatePackageCommandHandler(IAsyncRepository<Package> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<RequestResponseMessage> Handle(UpdatePackageCommand request, CancellationToken cancellationToken)
    {

        var entity = await _asyncRepository.GetByIdAsync(request.Id, null, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Package), request.Id);
        }

        var req = new RequestResponseMessage();


        var succeed = await _asyncRepository.Update(_mapper.Map<Package>(request), cancellationToken);

        if (succeed)
        {
            req.Message = "Package has been updated successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to update Package";
        req.Succeed = false;

        return req;
    }
}
