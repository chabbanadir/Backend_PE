using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Cables.Commands.UpdateCable;

public class UpdateCableCommandHandler : IRequestHandler<UpdateCableCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Cable> _asyncRepository;
    private readonly IMapper _mapper;

    public UpdateCableCommandHandler(IAsyncRepository<Cable> asyncRepository,IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<RequestResponseMessage> Handle(UpdateCableCommand request, CancellationToken cancellationToken)
    {
        var entity = await _asyncRepository.GetByIdAsync(request.Id, null, cancellationToken);

        var req = new RequestResponseMessage();

        if (entity == null)
        {
            throw new NotFoundException(nameof(Cable), request.Id);
        }

        var succeed = await _asyncRepository.Update(_mapper.Map<Cable>(request), cancellationToken);

        if (succeed)
        {
            req.Message = "Cable has been updated successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to update Cable";
        req.Succeed = false;

        return req;

    }
}
