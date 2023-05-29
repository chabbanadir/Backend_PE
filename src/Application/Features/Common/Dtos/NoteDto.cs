using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Entities.Tools;

namespace Backend.Application.Features.Common.Dtos;

public class NoteDto : IMapFrom<Note>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Order { get; set; }
}
