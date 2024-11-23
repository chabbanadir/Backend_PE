
using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Notes.Commands.UpdateNote;

public class UpdateNoteCommand : IRequest<RequestResponseMessage>, IMapFrom<Note>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Order { get; set; }
    public int NoteType { get; set; }
    public int Status { get; set; }
    /*public string? FK_ConfigId { get; set; }*/


    public void Mapping(Profile profile)
    {
        profile.CreateMap<Note, UpdateNoteCommand>().ReverseMap();
    }
}
