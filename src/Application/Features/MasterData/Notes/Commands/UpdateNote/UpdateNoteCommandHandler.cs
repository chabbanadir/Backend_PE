using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;


namespace Backend.Application.Features.MasterData.Notes.Commands.UpdateNote;

public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, RequestResponseMessage>
{

    private readonly IAsyncRepository<Note> _asyncRepository;
    private readonly IMapper _mapper;

    public UpdateNoteCommandHandler(IAsyncRepository<Note> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }


    public async Task<RequestResponseMessage> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {

        var entity = await _asyncRepository.GetByIdAsync(request.Id, null, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        var req = new RequestResponseMessage();


        var succeed = await _asyncRepository.Update(_mapper.Map<Note>(request), cancellationToken);

        if (succeed)
        {
            req.Message = "Note has been updated successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to update Note";
        req.Succeed = false;

        return req;
    }


}
