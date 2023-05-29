using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Commands.Parts.DeletePart;

public class DeletePartCommandHandler : IRequestHandler<DeletePartCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<ComponentPart> _asyncRepository;
    public DeletePartCommandHandler(
        IAsyncRepository<ComponentPart> asyncOemRepository)
    {
        _asyncRepository = asyncOemRepository;
    }


    public async Task<RequestResponseMessage> Handle(DeletePartCommand request, CancellationToken cancellationToken)
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
            req.Message = "Part has been deleted successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to delete part";
        req.Succeed = false;

        return req;
    }

}