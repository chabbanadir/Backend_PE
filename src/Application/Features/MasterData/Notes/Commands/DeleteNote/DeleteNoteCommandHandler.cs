using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Notes.Commands.DeleteNote;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, RequestResponseMessage>
{
    private readonly IAsyncRepository<Note> _asyncRepository;

    public DeleteNoteCommandHandler(IAsyncRepository<Note> asyncRepository)
    {
        _asyncRepository = asyncRepository;
    }


    public async Task<RequestResponseMessage> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null, cancellationToken);

        var req = new RequestResponseMessage();

        var res = false;


        req.Message = "Note has been deleted successfully";
        req.Succeed = true;


        if (entity != null)
        {
            res = await _asyncRepository.Delete(new Guid(request.Id), cancellationToken);
        }

        if (!res)
        {
            req.Message = "Unable to delete Note";
            req.Succeed = false;
        }

        return req;
    }
}
