using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using MediatR;

namespace Backend.Application.Features.MasterData.Notes.Commands.CreateNote;

public class CreateNoteCommand : IRequest<RequestResponseMessage>, IMapFrom<Note>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Order { get; set; }
    /*public string? FK_ConfigId { get; set; }*/
    public int NoteType { get; set; }
    public int Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Note,CreateNoteCommand> ().ReverseMap();
    }

}
