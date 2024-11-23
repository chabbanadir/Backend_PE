using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Packagess.Commands.CreatePackage;


public class CreatePackageCommandHandler : IRequestHandler<CreatePackageCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Package> _asyncRepository;
    private readonly IMapper _mapper;

    public CreatePackageCommandHandler(IAsyncRepository<Package> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<RequestResponseMessage> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
    {

        var entity = await _asyncRepository.Create(_mapper.Map<Package>(request), cancellationToken);
        var req = new RequestResponseMessage();


        if (entity != null)
        {
            req.Message = "Package has been created successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to create Package";
        req.Succeed = false;

        return req;
    }

}