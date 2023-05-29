using Backend.Application.Common.Exceptions;
using MediatR;

namespace Backend.Application.Features.MasterData.Notes.Commands.DeleteNote;

public class DeleteNoteCommand : IRequest<RequestResponseMessage>
{
    public string? Id { get; set; }
}