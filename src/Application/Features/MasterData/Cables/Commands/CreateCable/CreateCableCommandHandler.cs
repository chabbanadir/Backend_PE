using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Cables.Commands.CreateCable;

public class CreateCableCommandHandler : IRequestHandler<CreateCableCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Cable> _asyncRepository;
    private readonly IMapper _mapper;

    public CreateCableCommandHandler(
          IAsyncRepository<Cable> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<RequestResponseMessage> Handle(CreateCableCommand request, CancellationToken cancellationToken)
    {
        var req = new RequestResponseMessage();

        var succeed = await _asyncRepository.Create(_mapper.Map<Cable>(request), cancellationToken);

        if (succeed != null)
        {
            req.Message = "Cable has been created successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to update configuration";
        req.Succeed = false;

        return req;
    }

}