using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using MediatR;

namespace Backend.Application.Features.MasterData.Notes.Queries.GetNotesByType;

public class GetNotesByTypeQueryHandler : IRequestHandler<GetNotesByTypeQuery, List<GetNotesByTypeResponse>>
{
    private readonly IAsyncRepository<Note> asyncRepository;
    private readonly IMapper _mapper;

    public GetNotesByTypeQueryHandler(IAsyncRepository<Note> asyncRepository, IMapper mapper)
    {
        this.asyncRepository = asyncRepository;
        _mapper = mapper;
    }



    public async Task<List<GetNotesByTypeResponse>> Handle(GetNotesByTypeQuery request, CancellationToken cancellationToken)
    {
        var query = await asyncRepository.GetByAsync(item => item.NoteType == (NoteType) request.type, null, cancellationToken);

        return _mapper.Map<List<GetNotesByTypeResponse>>(query);
    }

}
