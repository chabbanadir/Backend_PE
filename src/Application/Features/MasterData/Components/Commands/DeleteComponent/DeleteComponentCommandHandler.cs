using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Commands.DeleteComponent;

public class DeleteComponentCommandHandler : IRequestHandler<DeleteComponentCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Component> _asyncRepository;
    public DeleteComponentCommandHandler(
        IAsyncRepository<Component> asyncOemRepository)
    {
        _asyncRepository = asyncOemRepository;
    }


    public async Task<RequestResponseMessage> Handle(DeleteComponentCommand request, CancellationToken cancellationToken)
    {
        var serchedEntity = await _asyncRepository.GetByIdAsync(request.Id, null, cancellationToken);


        if (serchedEntity == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

        var req = new RequestResponseMessage();


        var succeed = await _asyncRepository.Delete(request.Id, cancellationToken);

        if (succeed)
        {
            req.Message = "Component has been deleted successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to delete component";
        req.Succeed = false;

        return req;
    }

}
