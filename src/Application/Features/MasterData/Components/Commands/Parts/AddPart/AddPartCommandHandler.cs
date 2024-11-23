using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Commands.Parts.AddPart;
public class AddPartCommandHandler : IRequestHandler<AddPartCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Component> _asyncParentRepository;
    private readonly IAsyncRepository<ComponentPart> _asyncRepository;
    private readonly IMapper _mapper;

    public AddPartCommandHandler(
     IAsyncRepository<ComponentPart> asyncRepository,
     IAsyncRepository<Component> asyncParentRepository,
     IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _asyncParentRepository = asyncParentRepository;
        _mapper = mapper;
    }

    public async Task<RequestResponseMessage> Handle(AddPartCommand request, CancellationToken cancellationToken)
    {
        var item = await _asyncParentRepository.GetByIdAsync(new Guid(request.FK_ComponentId), null, cancellationToken);

        if (item == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

        var req = new RequestResponseMessage();


        var exsits = await _asyncRepository.GetByAsync(c => c.FK_PartId == new Guid(request.FK_PartId) && c.FK_ComponentId == new Guid(request.FK_ComponentId), null, cancellationToken);

        if (exsits.ToArray().Length != 0)
        {
            req.Message = "Part already affected";
            req.Succeed = true;
            return req;
        }
        else
        {
            var succeed = await _asyncRepository.Create(_mapper.Map<ComponentPart>(request), cancellationToken);
            if (succeed != null)
            {
                req.Message = "Part has been affected successfully";
                req.Succeed = true;
                return req;
            }
        }
    

        req.Message = "Unable to affect part";
        req.Succeed = false;

        return req;
    }

}
