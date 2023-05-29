using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Notes.Queries.GetNotesByType;

public class GetNotesByTypeResponse : IMapFrom<Note>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Order { get; set; }
    public NoteType NoteType { get; set; }
    public Status Status { get; set; }

    public virtual ConfigDto Config { get; set; } = null!;

}
