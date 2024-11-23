using MediatR;

namespace Backend.Application.Features.MasterData.Notes.Queries.GetNotesByType;

public class GetNotesByTypeQuery : IRequest<List<GetNotesByTypeResponse>>
{
    public int type { get; set; }
}
