using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using MediatR;

namespace Backend.Application.Features.MasterData.Notes.Commands.CreateNote;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, RequestResponseMessage>
{

    private readonly IAsyncRepository<Note> _asyncRepository;
    private readonly IMapper _mapper;

    public CreateNoteCommandHandler(IAsyncRepository<Note> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<RequestResponseMessage> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {

        var entity = await _asyncRepository.Create(_mapper.Map<Note>(request), cancellationToken);

        var req = new RequestResponseMessage();


        if (entity != null)
        {
            req.Message = "Note has been created successfully";
            req.Succeed = true;
            return req;
        }

        req.Message = "Unable to create Note";
        req.Succeed = false;

        return req;
    }
}
