using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Commands.Cables.DeleteCable;

public class DeleteCableCommandHandler : IRequestHandler<DeleteCableCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<ComponentCable> _asyncRepository;
    public DeleteCableCommandHandler(
        IAsyncRepository<ComponentCable> asyncOemRepository)
    {
        _asyncRepository = asyncOemRepository;
    }


    public async Task<RequestResponseMessage> Handle(DeleteCableCommand request, CancellationToken cancellationToken)
    {
        var serchedEntity = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null, cancellationToken);


        if (serchedEntity == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

        var req = new RequestResponseMessage();

        var succeed = await _asyncRepository.Delete(serchedEntity.Id, cancellationToken);

        if (succeed)
        {
            req.Message = "Cable has been deleted successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to delete cable";
        req.Succeed = false;

        return req;
    }

}