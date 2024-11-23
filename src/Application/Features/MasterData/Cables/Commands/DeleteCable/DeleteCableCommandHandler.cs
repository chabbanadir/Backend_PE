using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Cables.Commands.DeleteCable;

public class DeleteCableCommandHandler : IRequestHandler<DeleteCableCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Cable> _asyncRepository;

    public DeleteCableCommandHandler(IAsyncRepository<Cable> asyncRepository)
    {
        _asyncRepository = asyncRepository;
    }

    public async Task<RequestResponseMessage> Handle(DeleteCableCommand request, CancellationToken cancellationToken)
    {
        var entity = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null, cancellationToken);

        var req = new RequestResponseMessage();

        var res = false;


        req.Message = "Cable has been deleted successfully";
        req.Succeed = true;


        if (entity != null)
        {
            res = await _asyncRepository.Delete(new Guid(request.Id), cancellationToken);
        }

        if (!res)
        {
            req.Message = "Unable to delete Cable";
            req.Succeed = false;

        }

        return req;
    }
}
