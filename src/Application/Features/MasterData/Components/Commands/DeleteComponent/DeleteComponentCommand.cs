using Backend.Application.Common.Exceptions;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Commands.DeleteComponent;

public class DeleteComponentCommand : IRequest<RequestResponseMessage>
{
    public Guid Id { get; set; }
}
