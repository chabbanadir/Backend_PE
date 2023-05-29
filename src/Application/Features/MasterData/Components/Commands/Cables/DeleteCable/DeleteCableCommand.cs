using Backend.Application.Common.Exceptions;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Commands.Cables.DeleteCable;

public class DeleteCableCommand : IRequest<RequestResponseMessage>
{
    public string Id { get; set; }
}