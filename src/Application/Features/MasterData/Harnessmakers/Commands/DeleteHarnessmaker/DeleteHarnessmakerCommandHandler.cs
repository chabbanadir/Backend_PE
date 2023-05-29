using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;


namespace Backend.Application.Features.MasterData.Harnessmakers.Commands.DeleteHarnessmaker;

public class DeleteHarnessmakerCommandHandler : IRequestHandler<DeleteHarnessmakerCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Harnessmaker> _asyncRepository;


    public DeleteHarnessmakerCommandHandler(IAsyncRepository<Harnessmaker> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
    }

    public async Task<RequestResponseMessage> Handle(DeleteHarnessmakerCommand request, CancellationToken cancellationToken)
    {

        var entity = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Harnessmaker), request.Id);
        }


        var req = new RequestResponseMessage();


        var res = await _asyncRepository.Delete(new Guid(request.Id), cancellationToken);

        if (res)
        {
            req.Message = "HarnessMaker has been deleted successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to delete HarnessMaker";
        req.Succeed = false;

        return req;
    }
}
