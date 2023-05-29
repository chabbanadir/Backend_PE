using Backend.Application.Common.Exceptions;
using MediatR;

namespace Backend.Application.Features.MasterData.Components.Commands.Parts.DeletePart;

public class DeletePartCommand : IRequest<RequestResponseMessage>
{
    public string Id { get; set; }
}