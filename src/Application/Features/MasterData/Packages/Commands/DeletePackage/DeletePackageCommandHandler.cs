using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Packages.Commands.DeletePackage;

public class DeletePackageCommandHandler : IRequestHandler<DeletePackageCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Package> _asyncRepository;


    public DeletePackageCommandHandler(IAsyncRepository<Package> asyncRepository)
    {
        _asyncRepository = asyncRepository;
    }

    public async Task<RequestResponseMessage> Handle(DeletePackageCommand request, CancellationToken cancellationToken)
    {

        var entity = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null, cancellationToken);

        var req = new RequestResponseMessage();

        var res = false;


        req.Message = "Package has been deleted successfully";
        req.Succeed = true;


        if (entity != null)
        {
            res = await _asyncRepository.Delete(new Guid(request.Id), cancellationToken);
        }


        if (!res)
        {
            req.Message = "Unable to delete Package";
            req.Succeed = false;

        }

        return req;

    }
}
