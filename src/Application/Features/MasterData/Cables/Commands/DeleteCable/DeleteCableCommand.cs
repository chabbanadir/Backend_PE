using Backend.Application.Common.Exceptions;
using MediatR;

namespace Backend.Application.Features.MasterData.Cables.Commands.DeleteCable;

public class DeleteCableCommand : IRequest<RequestResponseMessage>
{
    public string? Id { get; set; }
}
