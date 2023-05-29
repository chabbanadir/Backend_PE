using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Configurations.Commands.DeleteConfiguration;

public class DeleteConfigurationCommandHandler : IRequestHandler<DeleteConfigurationCommand, RequestResponseMessage>
{

    private readonly IAsyncRepository<Config> _asyncRepository;

    public DeleteConfigurationCommandHandler(IAsyncRepository<Config> asyncRepository)
    {
        _asyncRepository = asyncRepository;
    }


    public async Task<RequestResponseMessage> Handle(DeleteConfigurationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null, cancellationToken);

        var req = new RequestResponseMessage();

        var res = false;


        req.Message = "Configuration has been deleted successfully";
        req.Succeed = true;


        if (entity != null)
        {
            res = await _asyncRepository.Delete(new Guid(request.Id), cancellationToken);
        }

        if (!res)
        {
            req.Message = "Unable to delete Configuration";
            req.Succeed = false;

        }

        return req;
    }
}