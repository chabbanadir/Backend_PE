using AutoMapper;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Notes.Queries.GetNotes;

public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, List<GetNotesResponse>>
{
    private readonly IAsyncRepository<Note> asyncRepository;
    private readonly IMapper _mapper;

    public GetNotesQueryHandler(IAsyncRepository<Note> asyncRepository, IMapper mapper)
    {
        this.asyncRepository = asyncRepository;
        _mapper = mapper;
    }



    public async Task<List<GetNotesResponse>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        var query = await asyncRepository.GetAllAsync(/*new[] { "Config" }*/null, cancellationToken);

        return _mapper.Map<List<GetNotesResponse>>(query);
    }

}