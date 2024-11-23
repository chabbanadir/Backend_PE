using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Oems.Commands.DeleteOem;

public class DeleteOemCommandHandler : IRequestHandler<DeleteOemCommand, RequestResponseMessage>
{
   private readonly IAsyncRepository<Oem> _asyncRepository;


    public DeleteOemCommandHandler(IAsyncRepository<Oem> asyncRepository)
    {
        _asyncRepository = asyncRepository;
    }

    public async Task<RequestResponseMessage> Handle(DeleteOemCommand request, CancellationToken cancellationToken)
    {

        var entity = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null,cancellationToken);
        
        var req = new RequestResponseMessage();

        var res = false;


        req.Message = "Oem has been deleted successfully";
        req.Succeed = true;


        if (entity != null)
        {
            res = await _asyncRepository.Delete(new Guid(request.Id), cancellationToken);
        }


        if (!res)
        {
            req.Message = "Unable to delete Oem";
            req.Succeed = false;

        }

        return req;

    }
}
