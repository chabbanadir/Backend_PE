using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Application.Features.MasterData.Infos.Commands.DeleteInfo;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Infos.Infos.DeleteInfo;

public class DeleteInfoCommandHandler : IRequestHandler<DeleteInfoCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Info> _asyncRepository;
    public DeleteInfoCommandHandler(
        IAsyncRepository<Info> asyncOemRepository)
    {
        _asyncRepository = asyncOemRepository;
    }


    public async Task<RequestResponseMessage> Handle(DeleteInfoCommand request, CancellationToken cancellationToken)
    {
        var serchedEntity = await _asyncRepository.GetByIdAsync((Guid)request.Id, null, cancellationToken);


        if (serchedEntity == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }

        var req = new RequestResponseMessage();


        var succeed = await _asyncRepository.Delete((Guid)request.Id, cancellationToken);

        if (succeed)
        {
            req.Message = "Info has been deleted successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to delete Info";
        req.Succeed = false;

        return req;
    }

}
