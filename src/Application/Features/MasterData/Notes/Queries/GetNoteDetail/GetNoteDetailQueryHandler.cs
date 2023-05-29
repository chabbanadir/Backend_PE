using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Notes.Queries.GetNoteDetail;

public class GetNoteDetailQueryHandler : IRequestHandler<GetNoteDetailQuery, NoteDetailVm>
{
    private readonly IAsyncRepository<Note> _asyncRepository;
    private readonly IMapper _mapper;

    public GetNoteDetailQueryHandler(IAsyncRepository<Note> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }

    public async Task<NoteDetailVm> Handle(GetNoteDetailQuery request, CancellationToken cancellationToken)
    {


        var item = await _asyncRepository.GetByIdAsync(new Guid(request.Id), null, cancellationToken);

        if (item == null)
        {
            throw new NotFoundException("The specified Id is not exists.");
        }


        return _mapper.Map<NoteDetailVm>(item);

    }

}
