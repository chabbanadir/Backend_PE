using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Commands.Cables.AddCable;

public class AddCableCommandHandler : IRequestHandler<AddCableCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Component> _asyncParentRepository;
    private readonly IAsyncRepository<ComponentCable> _asyncRepository;
    private readonly IMapper _mapper;

    public AddCableCommandHandler(
     IAsyncRepository<ComponentCable> asyncRepository,
     IAsyncRepository<Component> asyncParentRepository,
     IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _asyncParentRepository = asyncParentRepository;
        _mapper = mapper;
    }

    public async Task<RequestResponseMessage> Handle(AddCableCommand request, CancellationToken cancellationToken)
    {
        var item = await _asyncParentRepository.GetByIdAsync(new Guid(request.FK_ComponentId), null, cancellationToken);

        if (item == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

        var req = new RequestResponseMessage();

        var exsits = await _asyncRepository.GetByAsync(c => c.FK_CableId == new Guid(request.FK_CableId) && c.FK_ComponentId == new Guid(request.FK_ComponentId), null, cancellationToken);

        if (exsits.ToArray().Length != 0)
        {
            req.Message = "Cable already affected";
            req.Succeed = true;
            return req;
        }
        else
        {
            var succeed = await _asyncRepository.Create(_mapper.Map<ComponentCable>(request), cancellationToken);
            if (succeed != null)
            {
                req.Message = "Cable has been affected successfully";
                req.Succeed = true;
                return req;
            }
        }

        req.Message = "Unable to affect cable";
        req.Succeed = false;

        return req;
    }

}
