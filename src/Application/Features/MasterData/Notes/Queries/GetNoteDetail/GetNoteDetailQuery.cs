using MediatR;

namespace Backend.Application.Features.MasterData.Notes.Queries.GetNoteDetail;

public class GetNoteDetailQuery : IRequest<NoteDetailVm>
{
    public string? Id { get; set; }

}

